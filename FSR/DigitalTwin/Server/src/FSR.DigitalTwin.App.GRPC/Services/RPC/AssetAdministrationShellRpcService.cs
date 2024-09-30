using System.Net;
using AasCore.Aas3_0;
using AasxServerStandardBib.Exceptions;
using AasxServerStandardBib.Interfaces;
using AasxServerStandardBib.Logging;
using AdminShellNS.Exceptions;
using AutoMapper;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.Services.AssetAdministrationShellService;
using Grpc.Core;
using IO.Swagger.Lib.V3.Interfaces;
using IO.Swagger.Lib.V3.SerializationModifiers.Mappers;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Authorization;
using PagedResultPagingMetadata = FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.PagedResultPagingMetadata;

namespace FSR.DigitalTwin.App.GRPC.Services.RPC;

public class AssetAdministrationShellRpcService : AssetAdministrationShellService.AssetAdministrationShellServiceBase {
    private readonly IAppLogger<AssetAdministrationShellRpcService> _logger;
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
    
    public AssetAdministrationShellRpcService(IAppLogger<AssetAdministrationShellRpcService> logger, IAssetAdministrationShellService aasService, IBase64UrlDecoderService decoderService, IAasRepositoryApiHelperService aasRepoApiHelper, IReferenceModifierService referenceModifierService, IMappingService mappingService, IPathModifierService pathModifierService, ILevelExtentModifierService levelExtentModifierService, IPaginationService paginationService, IAuthorizationService authorizationService, IMapper mapper) {
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

    public override Task<GetAssetAdministrationShellRpcResponse> GetAssetAdministrationShell(GetAssetAdministrationShellRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received request to get the AAS with id {request.Id}.");
        GetAssetAdministrationShellRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
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

    public override Task<PutAssetAdministrationShellRpcResponse> PutAssetAdministrationShell(PutAssetAdministrationShellRpcRequest request, ServerCallContext context)
    {
        PutAssetAdministrationShellRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
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

    public override Task<GetAllSubmodelReferencesRpcResponse> GetAllSubmodelReferences(GetAllSubmodelReferencesRpcRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received request to get all the submodel references from the AAS with id {request.Id}.");
        GetAllSubmodelReferencesRpcResponse response = new() { StatusCode = (int) StatusCode.OK };
        try {
            var decodedAasIdentifier = _decoderService.Decode("aasIdentifier", request.Id);
            var submodels = _aasService.GetAllSubmodelReferencesFromAas(decodedAasIdentifier);
            var submodelPaginatedList = _paginationService.GetPaginatedList(submodels, new PaginationParameters(request.OutputModifier.Cursor, request.OutputModifier.Limit));
            response.PagingMetaData = _mapper.Map<PagedResultPagingMetadata>(submodelPaginatedList.paging_metadata);
            if (request.OutputModifier.Content == OutputContent.Normal) {
                response.Payload.AddRange(submodelPaginatedList.result.Select(x => _mapper.Map<ReferenceDTO>(x)) ?? []);
            }
            else {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<PostSubmodelReferenceRpcResponse> PostSubmodelReference(PostSubmodelReferenceRpcRequest request, ServerCallContext context)
    {
        var decodedAasIdentifier = _decoderService.Decode("aasIdentifier", request.Id);
        _logger.LogInformation($"Received request to create a submodel reference in the AAS with id {decodedAasIdentifier}");
        PostSubmodelReferenceRpcResponse response = new() { StatusCode = (int) HttpStatusCode.Created };
        try {
            var body = _mapper.Map<Reference>(request.SubmodelRef);
            var reference = _aasService.CreateSubmodelReferenceInAAS(body, decodedAasIdentifier);
            response.SubmodelRef = _mapper.Map<ReferenceDTO>(reference);
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (DuplicateException) { response.StatusCode = (int) HttpStatusCode.BadRequest; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<DeleteSubmodelReferenceRpcResponse> DeleteSubmodelReference(DeleteSubmodelReferenceRpcRequest request, ServerCallContext context)
    {
        var decodedAasIdentifier = _decoderService.Decode("aasIdentifier", request.Id);
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);
        _logger.LogInformation($"Received request to delete submodel reference with id {request.SubmodelId} from the AAS with id {request.Id}.");
        DeleteSubmodelReferenceRpcResponse response = new() { StatusCode = (int) HttpStatusCode.NoContent };
        try {
            _aasService.DeleteSubmodelReferenceById(decodedAasIdentifier, decodedSubmodelIdentifier);
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<GetAssetInformationRpcResponse> GetAssetInformation(GetAssetInformationRpcRequest request, ServerCallContext context)
    {
        var decodedAasIdentifier = _decoderService.Decode("aasIdentifier", request.Id);
        _logger.LogInformation($"Received request to get the AAS with id {decodedAasIdentifier}.");
        GetAssetInformationRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            var assetInfo = _aasService.GetAssetInformation(decodedAasIdentifier);
            response.AssetInformation = _mapper.Map<AssetInformationDTO>(assetInfo);
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<PutAssetInformationRpcResponse> PutAssetInformation(PutAssetInformationRpcRequest request, ServerCallContext context)
    {
        var decodedAasIdentifier = _decoderService.Decode("aasIdentifier", request.Id);
        _logger.LogInformation($"Received request to replace the asset information of the AAS with id {decodedAasIdentifier}");
        PutAssetInformationRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            IAssetInformation body = _mapper.Map<AssetInformation>(request.AssetInformation);
            _aasService.ReplaceAssetInformation(decodedAasIdentifier, body);
            response.AssetInformation = request.AssetInformation;
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }
}