using System.Net;
using AasCore.Aas3_0;
using AasxServerStandardBib.Exceptions;
using AasxServerStandardBib.Interfaces;
using AasxServerStandardBib.Logging;
using AdminShellNS.Exceptions;
using AutoMapper;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.Services.SubmodelRepository;
using Grpc.Core;
using IO.Swagger.Lib.V3.Interfaces;
using IO.Swagger.Lib.V3.SerializationModifiers.Mappers;
using IO.Swagger.Lib.V3.Services;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Authorization;
using PagedResultPagingMetadata = FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.PagedResultPagingMetadata;

namespace FSR.DigitalTwin.App.GRPC.Services.RPC;

public class SubmodelRepositoryRpcService : SubmodelRepositoryService.SubmodelRepositoryServiceBase {

    private readonly IAppLogger<SubmodelRepositoryRpcService> _logger;
    private readonly IBase64UrlDecoderService _decoderService;
    private readonly ISubmodelService _submodelService;
    private readonly IReferenceModifierService _referenceModifierService;
    private readonly IJsonQueryDeserializer _jsonQueryDeserializer;
    private readonly IMappingService _mappingService;
    private readonly IPathModifierService _pathModifierService;
    private readonly ILevelExtentModifierService _levelExtentModifierService;
    private readonly IPaginationService _paginationService;
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;

    public SubmodelRepositoryRpcService(IAppLogger<SubmodelRepositoryRpcService> logger, IBase64UrlDecoderService decoderService, ISubmodelService submodelService, IReferenceModifierService referenceModifierService, IJsonQueryDeserializer jsonQueryDeserializer, IMappingService mappingService, IPathModifierService pathModifierService, ILevelExtentModifierService levelExtentModifierService, IPaginationService paginationService, IAuthorizationService authorizationService, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _decoderService = decoderService ?? throw new ArgumentNullException(nameof(decoderService));
        _submodelService = submodelService ?? throw new ArgumentNullException(nameof(submodelService));
        _referenceModifierService = referenceModifierService ?? throw new ArgumentNullException(nameof(referenceModifierService));
        _jsonQueryDeserializer = jsonQueryDeserializer ?? throw new ArgumentNullException(nameof(jsonQueryDeserializer));
        _mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
        _pathModifierService = pathModifierService ?? throw new ArgumentNullException(nameof(pathModifierService));
        _levelExtentModifierService = levelExtentModifierService ?? throw new ArgumentNullException(nameof(pathModifierService));
        _paginationService = paginationService ?? throw new ArgumentNullException(nameof(pathModifierService));
        _authorizationService = authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public override Task<GetAllSubmodelsRpcResponse> GetAllSubmodels(GetAllSubmodelsRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received the request to get all Submodels.");

        var submodelList = _submodelService.GetAllSubmodels();
        var submodelPaginatedList = _paginationService.GetPaginatedList(submodelList, new PaginationParameters(request.OutputModifier.Cursor, request.OutputModifier.Limit));

        var response = new GetAllSubmodelsRpcResponse() { 
            StatusCode = (int) HttpStatusCode.OK,
            PagingMetaData = _mapper.Map<PagedResultPagingMetadata>(submodelPaginatedList.paging_metadata),
        };

        if (request.OutputModifier.Content == OutputContent.Normal) {
            response.Payload.AddRange(submodelPaginatedList.result.Select(x => _mapper.Map<SubmodelDTO>(x)) ?? []);
        }
        else if (request.OutputModifier.Content == OutputContent.Reference) {
            var references = _referenceModifierService.GetReferenceResult(submodelPaginatedList.result.ConvertAll(a => (IReferable)a));
            response.Reference.AddRange(references.Select(x => _mapper.Map<ReferenceDTO>(x)) ?? []);
        }
        else {
            response.StatusCode = (int) HttpStatusCode.BadRequest;
        }

        return Task.FromResult(response);
    }

    public override Task<GetSubmodelByIdRpcResponse> GetSubmodelById(GetSubmodelByIdRpcRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.Id);

        _logger.LogInformation($"Received request to get the Submodel with id {request.Id}.");

        GetSubmodelByIdRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };

        ISubmodel submodel;
        try {
            submodel = _submodelService.GetSubmodelById(decodedSubmodelIdentifier);
        }
        catch(NotFoundException) {
            response.StatusCode = (int) HttpStatusCode.NotFound;
            return Task.FromResult(response);
        }

        var authResult = _authorizationService.AuthorizeAsync(context.GetHttpContext().User, submodel, "SecurityPolicy").Result;
        if (!authResult.Succeeded) {
            response.StatusCode = (int) HttpStatusCode.Forbidden;
            return Task.FromResult(response);
        }

        var output = _levelExtentModifierService.ApplyLevelExtent(
            submodel, (LevelEnum)request.OutputModifier.Level, (ExtentEnum)request.OutputModifier.Extent);
        if (output is not ISubmodel) {
            throw new NullReferenceException("should not happen");
        }
        ISubmodel result = (ISubmodel) output;

        if (request.OutputModifier.Content == OutputContent.Normal) {
            response.Payload = _mapper.Map<SubmodelDTO>(submodel);
        }
        else if (request.OutputModifier.Content == OutputContent.Reference) {
            var reference = _referenceModifierService.GetReferenceResult(submodel);
            response.Reference = _mapper.Map<ReferenceDTO>(reference);
        }
        else {
            response.StatusCode = (int) HttpStatusCode.BadRequest;
        }

        return Task.FromResult(response);
    }

    public override Task<GetAllSubmodelsBySemanticIdRpcResponse> GetAllSubmodelsBySemanticId(GetAllSubmodelsBySemanticIdRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received a request to get all the submodels by SemanticId.");

        var reqSemanticId = _mapper.Map<Reference>(request.SemanticId);

        var submodelList = _submodelService.GetAllSubmodels(reqSemanticId);
        var submodelPaginatedList = _paginationService.GetPaginatedList(submodelList, new PaginationParameters(request.OutputModifier.Cursor, request.OutputModifier.Limit));

        var response = new GetAllSubmodelsBySemanticIdRpcResponse() { 
            StatusCode = (int) HttpStatusCode.OK,
            PagingMetaData = _mapper.Map<PagedResultPagingMetadata>(submodelPaginatedList.paging_metadata),
        };

        if (request.OutputModifier.Content == OutputContent.Normal) {
            response.Payload.AddRange(submodelPaginatedList.result.Select(x => _mapper.Map<SubmodelDTO>(x)) ?? []);
        }
        else if (request.OutputModifier.Content == OutputContent.Reference) {
            var references = _referenceModifierService.GetReferenceResult(submodelPaginatedList.result.ConvertAll(a => (IReferable)a));
            response.Reference.AddRange(references.Select(x => _mapper.Map<ReferenceDTO>(x)) ?? []);
        }
        else {
            response.StatusCode = (int) HttpStatusCode.BadRequest;
        }

        return Task.FromResult(response);
    }

    public override Task<GetAllSubmodelsByIdShortRpcResponse> GetAllSubmodelsByIdShort(GetAllSubmodelsByIdShortRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received a request to get all the submodels by ShortId.");

        var submodelList = _submodelService.GetAllSubmodels(null, request.IdShort);
        var submodelPaginatedList = _paginationService.GetPaginatedList(submodelList, new PaginationParameters(request.OutputModifier.Cursor, request.OutputModifier.Limit));

        var response = new GetAllSubmodelsByIdShortRpcResponse() { 
            StatusCode = (int) HttpStatusCode.OK,
            PagingMetaData = _mapper.Map<PagedResultPagingMetadata>(submodelPaginatedList.paging_metadata),
        };

        if (request.OutputModifier.Content == OutputContent.Normal) {
            response.Payload.AddRange(submodelPaginatedList.result.Select(x => _mapper.Map<SubmodelDTO>(x)) ?? []);
        }
        else if (request.OutputModifier.Content == OutputContent.Reference) {
            var references = _referenceModifierService.GetReferenceResult(submodelPaginatedList.result.ConvertAll(a => (IReferable)a));
            response.Reference.AddRange(references.Select(x => _mapper.Map<ReferenceDTO>(x)) ?? []);
        }
        else {
            response.StatusCode = (int) HttpStatusCode.BadRequest;
        }

        return Task.FromResult(response);
    }

    public override Task<PostSubmodelRpcResponse> PostSubmodel(PostSubmodelRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received request to create a submodel.");

        ISubmodel submodel = _mapper.Map<Submodel>(request.Submodel);

        var decodedAasIdentifier = _decoderService.Decode("aasIdentifier", request.AasIdentifier);

        var response = new PostSubmodelRpcResponse();

        try {
            var output = _submodelService.CreateSubmodel(submodel, decodedAasIdentifier);
            response.StatusCode = (int) HttpStatusCode.Created;
            response.Submodel = _mapper.Map<SubmodelDTO>(output);
        }
        catch (DuplicateException) {
            response.StatusCode = (int) HttpStatusCode.BadRequest;
        }

        return Task.FromResult(response);
    }

    public override Task<PutSubmodelByIdRpcResponse> PutSubmodelById(PutSubmodelByIdRpcRequest request, ServerCallContext context)
    {
        ISubmodel submodel = _mapper.Map<Submodel>(request.Submodel);
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.Submodel.Id);

        var response = new PutSubmodelByIdRpcResponse();

        try {
            _submodelService.ReplaceSubmodelById(decodedSubmodelIdentifier, submodel);
            response.StatusCode = (int) HttpStatusCode.OK;
            response.Submodel = _mapper.Map<SubmodelDTO>(request.Submodel);
        }
        catch (NotFoundException) {
            response.StatusCode = (int) HttpStatusCode.NotFound;
        }
        catch (MetamodelVerificationException) {
            response.StatusCode = (int) HttpStatusCode.BadRequest;
        }

        return Task.FromResult(response);
    }

    public override Task<DeleteSubmodelByIdRpcResponse> DeleteSubmodelById(DeleteSubmodelByIdRpcRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.Id);

        _logger.LogInformation($"Received request to delete Submodel with id {decodedSubmodelIdentifier}");
        
        var response = new DeleteSubmodelByIdRpcResponse();
        try {
            _submodelService.DeleteSubmodelById(decodedSubmodelIdentifier);
            response.StatusCode = (int) HttpStatusCode.NoContent;
        }
        catch (NotFoundException) {
            response.StatusCode = (int) HttpStatusCode.NotFound;
        }

        return Task.FromResult(response);
    }
}