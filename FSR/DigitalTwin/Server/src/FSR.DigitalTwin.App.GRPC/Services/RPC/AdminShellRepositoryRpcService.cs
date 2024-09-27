using System.Net;
using AasCore.Aas3_0;
using AasxServerStandardBib.Exceptions;
using AasxServerStandardBib.Interfaces;
using AasxServerStandardBib.Logging;
using AdminShellNS.Exceptions;
using AutoMapper;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.Services.AssetAdministrationShellRepository;
using Grpc.Core;
using IO.Swagger.Lib.V3.Interfaces;
using IO.Swagger.Lib.V3.SerializationModifiers.Mappers;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Authorization;
using PagedResultPagingMetadata = FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.PagedResultPagingMetadata;

namespace FSR.DigitalTwin.App.GRPC.Services.RPC;

public class AssetAdministrationShellRepositoryRpcService : AssetAdministrationShellRepositoryService.AssetAdministrationShellRepositoryServiceBase {
    
    private readonly IAppLogger<AssetAdministrationShellRepositoryRpcService> _logger;
    private readonly IAssetAdministrationShellService _aasService;
    private readonly IBase64UrlDecoderService _decoderService;
    private readonly IAasRepositoryApiHelperService _aasRepoApiHelper;
    private readonly IReferenceModifierService _referenceModifierService;
    private readonly IMappingService _mappingService;
    private readonly IPathModifierService _pathModifierService;
    private readonly ILevelExtentModifierService _levelExtentModifierService;
    private readonly IPaginationService _paginationService;
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    
    public AssetAdministrationShellRepositoryRpcService(IAppLogger<AssetAdministrationShellRepositoryRpcService> logger, IAssetAdministrationShellService aasService, IBase64UrlDecoderService decoderService, IAasRepositoryApiHelperService aasRepoApiHelper, IReferenceModifierService referenceModifierService, IMappingService mappingService, IPathModifierService pathModifierService, ILevelExtentModifierService levelExtentModifierService, IPaginationService paginationService, IAuthorizationService authorizationService, IMapper mapper) {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _aasService = aasService ?? throw new ArgumentNullException(nameof(aasService));
        _decoderService = decoderService ?? throw new ArgumentNullException(nameof(decoderService));
        _aasRepoApiHelper = aasRepoApiHelper ?? throw new ArgumentNullException(nameof(aasRepoApiHelper));
        _referenceModifierService = referenceModifierService ?? throw new ArgumentNullException(nameof(referenceModifierService));
        _mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
        _pathModifierService = pathModifierService ?? throw new ArgumentNullException(nameof(pathModifierService));
        _levelExtentModifierService = levelExtentModifierService ?? throw new ArgumentNullException(nameof(levelExtentModifierService));
        _paginationService = paginationService ?? throw new ArgumentNullException(nameof(levelExtentModifierService));
        _authorizationService = authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public override Task<GetAllAssetAdministrationShellsRpcResponse> GetAllAssetAdministrationShells(GetAllAssetAdministrationShellsRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received the request to get all Asset Administration Shells.");
        GetAllAssetAdministrationShellsRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            var aasList = _aasService.GetAllAssetAdministrationShells();
            var aasPaginatedList = _paginationService.GetPaginatedList(aasList, new PaginationParameters(request.OutputModifier.Cursor, request.OutputModifier.Limit));
            response.PagingMetaData = _mapper.Map<PagedResultPagingMetadata>(aasPaginatedList.paging_metadata);

            if (request.OutputModifier.Content == OutputContent.Normal) {
                response.Payload.AddRange(aasPaginatedList.result.Select(x => _mapper.Map<AssetAdministrationShellDTO>(x)) ?? []);
            }
            else if (request.OutputModifier.Content == OutputContent.Reference) {
                var references = _referenceModifierService.GetReferenceResult(aasPaginatedList.result.ConvertAll(a => (IReferable)a));
                response.Reference.AddRange(references.Select(x => _mapper.Map<ReferenceDTO>(x)) ?? []);
            }
            else {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<GetAssetAdministrationShellByIdRpcResponse> GetAssetAdministrationShellById(GetAssetAdministrationShellByIdRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received request to get the AAS with id {request.Id}.");
        GetAssetAdministrationShellByIdRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            var decodedAasIdentifier = _decoderService.Decode("aasIdentifier", request.Id);
            var aas = _aasService.GetAssetAdministrationShellById(decodedAasIdentifier);
            if (request.OutputModifier.Content == OutputContent.Normal) {
                response.Payload = _mapper.Map<AssetAdministrationShellDTO>(aas);
            }
            else if (request.OutputModifier.Content == OutputContent.Reference) {
                var reference = _referenceModifierService.GetReferenceResult(aas);
                response.Reference = _mapper.Map<ReferenceDTO>(reference);
            }
            else {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<GetAllAssetAdministrationShellsByAssetIdRpcResponse> GetAllAssetAdministrationShellsByAssetId(GetAllAssetAdministrationShellsByAssetIdRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received the request to get all Asset Administration Shells by AssetId.");
        GetAllAssetAdministrationShellsByAssetIdRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            SpecificAssetId specificAssetId = new(request.KeyIdentifier, request.Key);

            var aasList = _aasService.GetAllAssetAdministrationShells([specificAssetId]);
            var aasPaginatedList = _paginationService.GetPaginatedList(aasList, new PaginationParameters(request.OutputModifier.Cursor, request.OutputModifier.Limit));

            response.PagingMetaData = _mapper.Map<PagedResultPagingMetadata>(aasPaginatedList.paging_metadata);

            if (request.OutputModifier.Content == OutputContent.Normal) {
                response.Payload.AddRange(aasPaginatedList.result.Select(x => _mapper.Map<AssetAdministrationShellDTO>(x)) ?? []);
            }
            else if (request.OutputModifier.Content == OutputContent.Reference) {
                var references = _referenceModifierService.GetReferenceResult(aasPaginatedList.result.ConvertAll(a => (IReferable)a));
                response.Reference.AddRange(references.Select(x => _mapper.Map<ReferenceDTO>(x)) ?? []);
            }
            else {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<GetAllAssetAdministrationShellsByIdShortRpcResponse> GetAllAssetAdministrationShellsByIdShort(GetAllAssetAdministrationShellsByIdShortRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received the request to get all Asset Administration Shells by IdShort.");
        GetAllAssetAdministrationShellsByIdShortRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            var aasList = _aasService.GetAllAssetAdministrationShells(null, request.IdShort);
            var aasPaginatedList = _paginationService.GetPaginatedList(aasList, new PaginationParameters(request.OutputModifier.Cursor, request.OutputModifier.Limit));
            response.PagingMetaData = _mapper.Map<PagedResultPagingMetadata>(aasPaginatedList.paging_metadata);

            if (request.OutputModifier.Content == OutputContent.Normal) {
                response.Payload.AddRange(aasPaginatedList.result.Select(x => _mapper.Map<AssetAdministrationShellDTO>(x)) ?? []);
            }
            else if (request.OutputModifier.Content == OutputContent.Reference) {
                var references = _referenceModifierService.GetReferenceResult(aasPaginatedList.result.ConvertAll(a => (IReferable)a));
                response.Reference.AddRange(references.Select(x => _mapper.Map<ReferenceDTO>(x)) ?? []);
            }
            else {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<PostAssetAdministrationShellRpcResponse> PostAssetAdministrationShell(PostAssetAdministrationShellRpcRequest request, ServerCallContext context)
    {
        PostAssetAdministrationShellRpcResponse response = new() { StatusCode = (int) HttpStatusCode.Created };
        try {
            IAssetAdministrationShell aas = _mapper.Map<AssetAdministrationShell>(request.Aas);
            var output = _aasService.CreateAssetAdministrationShell(aas);
            response.Aas = _mapper.Map<AssetAdministrationShellDTO>(output);
        }
        catch (DuplicateException) { response.StatusCode = (int) HttpStatusCode.BadRequest; }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<PutAssetAdministrationShellByIdRpcResponse> PutAssetAdministrationShellById(PutAssetAdministrationShellByIdRpcRequest request, ServerCallContext context)
    {
        PutAssetAdministrationShellByIdRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            IAssetAdministrationShell aas = _mapper.Map<AssetAdministrationShell>(request.Aas);
            var decodedAasIdentifier = _decoderService.Decode("aasIdentifier", request.Aas.Id);
            _aasService.ReplaceAssetAdministrationShellById(decodedAasIdentifier, aas);
            response.Aas = _mapper.Map<AssetAdministrationShellDTO>(request.Aas);
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (MetamodelVerificationException) { response.StatusCode = (int) HttpStatusCode.BadRequest; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<DeleteAssetAdministrationShellByIdRpcResponse> DeleteAssetAdministrationShellById(DeleteAssetAdministrationShellByIdRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received request to delete AAS with id {request.Id}");
        DeleteAssetAdministrationShellByIdRpcResponse response = new() { StatusCode = (int) HttpStatusCode.NoContent };
        try {
            var decodedAasIdentifier = _decoderService.Decode("aasIdentifier", request.Id);
            _aasService.DeleteAssetAdministrationShellById(decodedAasIdentifier);
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }
}