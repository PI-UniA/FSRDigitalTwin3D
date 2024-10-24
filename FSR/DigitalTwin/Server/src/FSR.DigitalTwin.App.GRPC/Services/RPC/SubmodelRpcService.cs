using System.Net;
using System.Security.Claims;
using AasCore.Aas3_0;
using AasxServer;
using AasxServerStandardBib.Exceptions;
using AasxServerStandardBib.Interfaces;
using AasxServerStandardBib.Logging;
using AdminShellNS;
using AdminShellNS.Exceptions;
using AutoMapper;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.Services.Services.SubmodelService;
using Grpc.Core;
using IO.Swagger.Lib.V3.Interfaces;
using IO.Swagger.Lib.V3.SerializationModifiers.Mappers;
using IO.Swagger.Lib.V3.Services;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Authorization;
using ExecutionState = FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.ExecutionState;
using OperationResult = FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.OperationResult;
using PagedResultPagingMetadata = FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.PagedResultPagingMetadata;

namespace FSR.DigitalTwin.App.GRPC.Services.RPC;

public class SubmodelRpcService : SubmodelService.SubmodelServiceBase {

    private readonly IAppLogger<SubmodelRpcService> _logger;
    private readonly IBase64UrlDecoderService _decoderService;
    private readonly ISubmodelService _submodelService;
    private readonly IReferenceModifierService _referenceModifierService;
    private readonly IJsonQueryDeserializer _jsonQueryDeserializer;
    private readonly IMappingService _mappingService;
    private readonly IPathModifierService _pathModifierService;
    private readonly ILevelExtentModifierService _levelExtentModifierService;
    private readonly IPaginationService _paginationService;
    private readonly IAuthorizationService _authorizationService;
    private readonly IOperationReceiver _operationReceiver;
    private readonly IMapper _mapper;

    public SubmodelRpcService(IAppLogger<SubmodelRpcService> logger, IBase64UrlDecoderService decoderService, ISubmodelService submodelService, IReferenceModifierService referenceModifierService, IJsonQueryDeserializer jsonQueryDeserializer, IMappingService mappingService, IPathModifierService pathModifierService, ILevelExtentModifierService levelExtentModifierService, IPaginationService paginationService, IAuthorizationService authorizationService, IOperationReceiver operationReceiver, IMapper mapper)
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
        _operationReceiver = operationReceiver ?? throw new ArgumentNullException(nameof(operationReceiver));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public override Task<GetSubmodelRpcResponse> GetSubmodel(GetSubmodelRpcRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);
        _logger.LogInformation($"Received request to get the Submodel with id {request.SubmodelId}.");
        GetSubmodelRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            ISubmodel submodel = _submodelService.GetSubmodelById(decodedSubmodelIdentifier);

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
            submodel = (ISubmodel) output;

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
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<GetAllSubmodelElementsRpcResponse> GetAllSubmodelElements(GetAllSubmodelElementsRpcRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);
        _logger.LogInformation($"Received a request to get all the submodel elements from submodel with id {decodedSubmodelIdentifier}");
        GetAllSubmodelElementsRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };

        try {
            if (!Program.noSecurity)
            {
                var submodel = _submodelService.GetSubmodelById(decodedSubmodelIdentifier);
                var authResult = _authorizationService.AuthorizeAsync(context.GetHttpContext().User, submodel, "SecurityPolicy").Result;
                if (!authResult.Succeeded)
                {
                    response.StatusCode = (int) HttpStatusCode.Forbidden;
                    return Task.FromResult(response);
                }
            }
            
            var submodelElements = _submodelService.GetAllSubmodelElements(decodedSubmodelIdentifier);
            var smePaginatedList = _paginationService.GetPaginatedList(submodelElements, new PaginationParameters(request.OutputModifier.Cursor, request.OutputModifier.Limit));
        
            response.PagingMetaData = _mapper.Map<PagedResultPagingMetadata>(smePaginatedList.paging_metadata);

            if (request.OutputModifier.Content == OutputContent.Normal) {
                var smeLevelExtent = _levelExtentModifierService.ApplyLevelExtent(smePaginatedList.result, (LevelEnum)request.OutputModifier.Level, (ExtentEnum)request.OutputModifier.Extent);
                response.Payload.AddRange(smeLevelExtent.Select(x => _mapper.Map<SubmodelElementDTO>((ISubmodelElement) x)) ?? []);
            }
            else if (request.OutputModifier.Content == OutputContent.Reference) {
                var references = _referenceModifierService.GetReferenceResult(smePaginatedList.result.ConvertAll(a => (IReferable)a));
                response.Reference.AddRange(references.Select(x => _mapper.Map<ReferenceDTO>(x)) ?? []);
            }
            else if (request.OutputModifier.Content == OutputContent.Path) {
                var paths = _pathModifierService.ToIdShortPath(submodelElements);
                response.Path.AddRange(paths.Select(ToIdShortDotSeparatedPath) ?? []);
            }
            else if (request.OutputModifier.Content == OutputContent.Value) {
                var smeLevelExtent = _levelExtentModifierService.ApplyLevelExtent(smePaginatedList.result, (LevelEnum)request.OutputModifier.Level, (ExtentEnum)request.OutputModifier.Extent);
                var smeValues = _mappingService.Map(smeLevelExtent, "value");
                throw new NotImplementedException(); // TODO Transferring values still WIP
            }
            else {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    private string ToIdShortDotSeparatedPath(IEnumerable<string> path) {
        string res = "";
        bool first = true;

        foreach(string idShort in path) {
            if (!first) {
                res += ".";
            }
            first = false;
            res += idShort;
        }

        return res;
    }

    public override Task<GetSubmodelElementByPathRpcResponse> GetSubmodelElementByPath(GetSubmodelElementByPathRpcRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);
        _logger.LogInformation($"Received request to path of the submodel element at {request.SubmodelId} from a submodel with id {decodedSubmodelIdentifier}");
        GetSubmodelElementByPathRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };

        try {
            string idShortPath = ToIdShortDotSeparatedPath(request.Path.Select(x => x.Value));
            var submodelElement = _submodelService.GetSubmodelElementByPath(decodedSubmodelIdentifier, idShortPath);
            if (!Program.noSecurity)
            {
                var submodel = _submodelService.GetSubmodelById(decodedSubmodelIdentifier);
                context.GetHttpContext().User.Claims.ToList().Add(new Claim("idShortPath", submodel.IdShort + "." + idShortPath));
                var claimsList = new List<Claim>(context.GetHttpContext().User.Claims)
                {
                    new Claim("IdShortPath", submodel.IdShort + "." + idShortPath)
                };
                var identity = new ClaimsIdentity(claimsList, "AasSecurityAuth");
                var principal = new System.Security.Principal.GenericPrincipal(identity, null);
                var authResult = _authorizationService.AuthorizeAsync(principal, submodel, "SecurityPolicy").Result;
                if (!authResult.Succeeded)
                {
                    response.StatusCode = (int) HttpStatusCode.Forbidden;
                    return Task.FromResult(response);
                }
            }

            if (request.OutputModifier.Content == OutputContent.Normal) {
                var submodelElementLevel = _levelExtentModifierService.ApplyLevelExtent(submodelElement, (LevelEnum)request.OutputModifier.Level);
                response.Payload = _mapper.Map<SubmodelElementDTO>((ISubmodelElement) submodelElementLevel);
            }
            else if (request.OutputModifier.Content == OutputContent.Reference) {
                var reference = _referenceModifierService.GetReferenceResult(submodelElement);
                response.Reference = _mapper.Map<ReferenceDTO>(reference);
            }
            else if (request.OutputModifier.Content == OutputContent.Path) {
                var path = _pathModifierService.ToIdShortPath(submodelElement);
                response.Path = ToIdShortDotSeparatedPath(path);
            }
            else if (request.OutputModifier.Content == OutputContent.Value) {
                var submodelElementLevel = _levelExtentModifierService.ApplyLevelExtent(submodelElement, (LevelEnum)request.OutputModifier.Level);
                var smeValues = _mappingService.Map(submodelElementLevel, "value");
                throw new NotImplementedException(); // TODO Transferring values still WIP
            }
            else {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<PutSubmodelRpcResponse> PutSubmodel(PutSubmodelRpcRequest request, ServerCallContext context)
    {
        ISubmodel submodel = _mapper.Map<Submodel>(request.Submodel);
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);

        PutSubmodelRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };

        try {
            _submodelService.ReplaceSubmodelById(decodedSubmodelIdentifier, submodel);
            response.Submodel = _mapper.Map<SubmodelDTO>(request.Submodel);
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (MetamodelVerificationException) { response.StatusCode = (int) HttpStatusCode.BadRequest; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<PostSubmodelElementRpcResponse> PostSubmodelElement(PostSubmodelElementRpcRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);
        _logger.LogInformation($"Received request to create a new submodel element in the submodel with id {decodedSubmodelIdentifier}");
        PostSubmodelElementRpcResponse response = new() { StatusCode = (int) HttpStatusCode.Created };
        try {
            var body = _mapper.Map<ISubmodelElement>(request.SubmodelElement);
            if (!Program.noSecurity)
            {
                var submodel = _submodelService.GetSubmodelById(decodedSubmodelIdentifier);
                var claimsList = new List<Claim>(context.GetHttpContext().User.Claims)
                {
                    new Claim("IdShortPath", submodel.IdShort + "." + body.IdShort)
                };
                var identity = new ClaimsIdentity(claimsList, "AasSecurityAuth");
                var principal = new System.Security.Principal.GenericPrincipal(identity, null);
                var authResult = _authorizationService.AuthorizeAsync(principal, submodel, "SecurityPolicy").Result;
                if (!authResult.Succeeded)
                {
                    response.StatusCode = (int) HttpStatusCode.Forbidden;
                    return Task.FromResult(response);
                }
            }
            var res = _submodelService.CreateSubmodelElement(decodedSubmodelIdentifier, body, true);
            response.SubmodelElement = _mapper.Map<SubmodelElementDTO>(res);

        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (DuplicateException) { response.StatusCode = (int) HttpStatusCode.BadRequest; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<PostSubmodelElementByPathRpcResponse> PostSubmodelElementByPath(PostSubmodelElementByPathRpcRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);
        string idShortPath = ToIdShortDotSeparatedPath(request.Path.Select(x => x.Value));
        _logger.LogInformation($"Received request to create a new submodel element at {idShortPath} in the submodel with id {decodedSubmodelIdentifier}");
        PostSubmodelElementByPathRpcResponse response = new() { StatusCode = (int) HttpStatusCode.Created };
        try {
            var body = _mapper.Map<ISubmodelElement>(request.SubmodelElement);
            if (!Program.noSecurity)
            {
                var submodel = _submodelService.GetSubmodelById(decodedSubmodelIdentifier);
                context.GetHttpContext().User.Claims.ToList().Add(new Claim("idShortPath", submodel.IdShort + "." + idShortPath));
                var claimsList = new List<Claim>(context.GetHttpContext().User.Claims)
                {
                    new Claim("IdShortPath", submodel.IdShort + "." + idShortPath)
                };
                var identity = new ClaimsIdentity(claimsList, "AasSecurityAuth");
                var principal = new System.Security.Principal.GenericPrincipal(identity, null);
                var authResult = _authorizationService.AuthorizeAsync(principal, submodel, "SecurityPolicy").Result;
                if (!authResult.Succeeded)
                {
                    response.StatusCode = (int) HttpStatusCode.Unauthorized;
                    return Task.FromResult(response);
                }
            }
            var res = _submodelService.CreateSubmodelElementByPath(decodedSubmodelIdentifier, idShortPath, true, body);
            response.StatusCode = (int) HttpStatusCode.Created;
            response.SubmodelElement = _mapper.Map<SubmodelElementDTO>(res);
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (DuplicateException) { response.StatusCode = (int) HttpStatusCode.BadRequest; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<PutSubmodelElementByPathRpcResponse> PutSubmodelElementByPath(PutSubmodelElementByPathRpcRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);
        string idShortPath = ToIdShortDotSeparatedPath(request.Path.Select(x => x.Value));
        _logger.LogInformation($"Received request to replace a submodel element at {idShortPath} deom the submodel with id {decodedSubmodelIdentifier}.");
        PutSubmodelElementByPathRpcResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            var body = _mapper.Map<ISubmodelElement>(request.SubmodelElement);
            if (!Program.noSecurity)
            {
                var submodel = _submodelService.GetSubmodelById(decodedSubmodelIdentifier);
                var claimsList = new List<Claim>(context.GetHttpContext().User.Claims)
                {
                    new Claim("IdShortPath", submodel.IdShort + "." + body.IdShort)
                };
                var identity = new ClaimsIdentity(claimsList, "AasSecurityAuth");
                var principal = new System.Security.Principal.GenericPrincipal(identity, null);
                var authResult = _authorizationService.AuthorizeAsync(principal, submodel, "SecurityPolicy").Result;
                if (!authResult.Succeeded)
                {
                    response.StatusCode = (int) HttpStatusCode.Unauthorized;
                    return Task.FromResult(response);
                }
            }
            _submodelService.ReplaceSubmodelElementByPath(decodedSubmodelIdentifier, idShortPath, body);
            response.SubmodelElement = _mapper.Map<SubmodelElementDTO>(request.SubmodelElement);

        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (MetamodelVerificationException) { response.StatusCode = (int) HttpStatusCode.BadRequest; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<SetSubmodelElementValueByPathRpcResponse> SetSubmodelElementValueByPath(SetSubmodelElementValueByPathRpcRequest request, ServerCallContext context)
    {
        // TODO: Setting values directly is still unfeatured
        SetSubmodelElementValueByPathRpcResponse response = new() { StatusCode = (int) HttpStatusCode.NotImplemented };
        return Task.FromResult(response);
        // throw new NotImplementedException();
    }

    public override Task<DeleteSubmodelElementByPathRpcResponse> DeleteSubmodelElementByPath(DeleteSubmodelElementByPathRpcRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);
        string idShortPath = ToIdShortDotSeparatedPath(request.Path.Select(x => x.Value));
        _logger.LogInformation($"Received a request to delete a submodel element at {idShortPath} from submodel with id {decodedSubmodelIdentifier}");
        DeleteSubmodelElementByPathRpcResponse response = new() { StatusCode = (int) HttpStatusCode.NoContent };
        try {
            if (!Program.noSecurity)
            {
                var submodel = _submodelService.GetSubmodelById(decodedSubmodelIdentifier);
                context.GetHttpContext().User.Claims.ToList().Add(new Claim("idShortPath", submodel.IdShort + "." + idShortPath));
                var claimsList = new List<Claim>(context.GetHttpContext().User.Claims)
                {
                    new Claim("IdShortPath", submodel.IdShort + "." + idShortPath)
                };
                var identity = new ClaimsIdentity(claimsList, "AasSecurityAuth");
                var principal = new System.Security.Principal.GenericPrincipal(identity, null);
                var authResult = _authorizationService.AuthorizeAsync(principal, submodel, "SecurityPolicy").Result;
                if (!authResult.Succeeded)
                {
                    response.StatusCode = (int) HttpStatusCode.BadRequest;
                    return Task.FromResult(response);
                }
            }
            _submodelService.DeleteSubmodelElementByPath(decodedSubmodelIdentifier, idShortPath);
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<InvokeOperationAsyncResponse> InvokeOperationAsync(InvokeOperationAsyncRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);
        _logger.LogInformation($"Received request to invoke operation at {request.SubmodelId} from a submodel with id {decodedSubmodelIdentifier}");
        InvokeOperationAsyncResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            string idShortPath = ToIdShortDotSeparatedPath(request.Path.Select(x => x.Value));
            if (!Program.noSecurity)
            {
                var submodel = _submodelService.GetSubmodelById(decodedSubmodelIdentifier);
                context.GetHttpContext().User.Claims.ToList().Add(new Claim("idShortPath", submodel.IdShort + "." + idShortPath));
                var claimsList = new List<Claim>(context.GetHttpContext().User.Claims)
                {
                    new Claim("IdShortPath", submodel.IdShort + "." + idShortPath)
                };
                var identity = new ClaimsIdentity(claimsList, "AasSecurityAuth");
                var principal = new System.Security.Principal.GenericPrincipal(identity, null);
                var authResult = _authorizationService.AuthorizeAsync(principal, submodel, "SecurityPolicy").Result;
                if (!authResult.Succeeded)
                {
                    response.StatusCode = (int) HttpStatusCode.Forbidden;
                    return Task.FromResult(response);
                }
            }
            List<OperationVariable> inputArguments = request.InputArguments.Select(x => _mapper.Map<OperationVariable>(x)).ToList();
            List<OperationVariable> inoutputArguments = request.InoutputArguments.Select(x => _mapper.Map<OperationVariable>(x)).ToList();
            var handle = _submodelService.InvokeOperationAsync(decodedSubmodelIdentifier, idShortPath, inputArguments, inoutputArguments, request.Timestamp, request.RequestId);
            response.Payload = handle.HandleId;
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<InvokeOperationSyncResponse> InvokeOperationSync(InvokeOperationSyncRequest request, ServerCallContext context)
    {
        var decodedSubmodelIdentifier = _decoderService.Decode("submodelIdentifier", request.SubmodelId);
        _logger.LogInformation($"Received request to invoke operation at {request.SubmodelId} from a submodel with id {decodedSubmodelIdentifier}");
        InvokeOperationSyncResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            string idShortPath = ToIdShortDotSeparatedPath(request.Path.Select(x => x.Value));
            if (!Program.noSecurity)
            {
                var submodel = _submodelService.GetSubmodelById(decodedSubmodelIdentifier);
                context.GetHttpContext().User.Claims.ToList().Add(new Claim("idShortPath", submodel.IdShort + "." + idShortPath));
                var claimsList = new List<Claim>(context.GetHttpContext().User.Claims)
                {
                    new Claim("IdShortPath", submodel.IdShort + "." + idShortPath)
                };
                var identity = new ClaimsIdentity(claimsList, "AasSecurityAuth");
                var principal = new System.Security.Principal.GenericPrincipal(identity, null);
                var authResult = _authorizationService.AuthorizeAsync(principal, submodel, "SecurityPolicy").Result;
                if (!authResult.Succeeded)
                {
                    response.StatusCode = (int) HttpStatusCode.Forbidden;
                    return Task.FromResult(response);
                }
            }
            List<OperationVariable> inputArguments = request.InputArguments.Select(x => _mapper.Map<OperationVariable>(x)).ToList();
            List<OperationVariable> inoutputArguments = request.InoutputArguments.Select(x => _mapper.Map<OperationVariable>(x)).ToList();
            var result = _submodelService.InvokeOperationSync(decodedSubmodelIdentifier, idShortPath, inputArguments, inoutputArguments, request.Timestamp, request.RequestId);
            OperationResult operationResult = new() {
                RequestId = result.RequestId,
                Success = result.Success,
                Message = result.Message,
                ExecutionState = (ExecutionState)result.ExecutionState
            };
            operationResult.InoutputArguments.AddRange(result.InoutputArguments?.Select(x => _mapper.Map<OperationVariableDTO>(x)) ?? []);
            operationResult.OutputArguments.AddRange(result.OutputArguments?.Select(x => _mapper.Map<OperationVariableDTO>(x)) ?? []);
            response.Payload = operationResult;
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }

    public override Task<GetOperationAsyncResultResponse> GetOperationAsyncResult(GetOperationAsyncResultRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Received request get status/result from invocation {request.HandleId}");
        GetOperationAsyncResultResponse response = new() { StatusCode = (int) HttpStatusCode.OK };
        try {
            var result = _operationReceiver.GetResult(request.HandleId);
            OperationResult operationResult = new() {
                RequestId = result.RequestId,
                Success = result.Success,
                Message = result.Message,
                ExecutionState = (ExecutionState)result.ExecutionState
            };
            operationResult.InoutputArguments.AddRange(result.InoutputArguments?.Select(x => _mapper.Map<OperationVariableDTO>(x)) ?? []);
            operationResult.OutputArguments.AddRange(result.OutputArguments?.Select(x => _mapper.Map<OperationVariableDTO>(x)) ?? []);
            response.Result = operationResult;
            _logger.LogInformation($"Invocation {request.HandleId} has current status {result.ExecutionState}");
        }
        catch (NotFoundException) { response.StatusCode = (int) HttpStatusCode.NotFound; }
        catch (Exception) { response.StatusCode = (int) HttpStatusCode.InternalServerError; }
        return Task.FromResult(response);
    }
}