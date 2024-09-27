using System;
using System.Linq;
using System.Threading.Tasks;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.Services.AssetAdministrationShellRepository;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.Services.AssetAdministrationShellService;
using FSR.DigitalTwin.App.GRPC.Aas.Lib.V3.Services.Services.SubmodelService;
using FSR.DigitalTwin.Client.Unity.GRPC.AAS.Utils;
using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;
using Grpc.Core;

namespace FSR.DigitalTwin.Client.Unity.GRPC.AAS {

    public class GrpcDigitalWorkspaceApiBridge : IDigitalWorkspaceEntityApi
    {
        private readonly GrpcAdminShellApiServiceClient _client;
        private static OutputModifier DefaultOutput = new() { 
            Content = OutputContent.Normal, 
            Extent = OutputExtent.WithoutBlobValue, 
            Level = OutputLevel.Deep,
            Cursor = "",
            Limit = 32
        };

        public GrpcDigitalWorkspaceApiBridge(Channel channel) {
            _client = new(channel);
        }

        public async Task<string[]> GetEntitesAsync()
        {
            GetAllAssetAdministrationShellsRpcRequest request = new() { OutputModifier = DefaultOutput };
            var response = await _client.AdminShellRepo.GetAllAssetAdministrationShellsAsync(request);
            return response.Payload.Select(x => x.Id).ToArray();
        }

        public string[] GetEntities()
        {
            GetAllAssetAdministrationShellsRpcRequest request = new() { OutputModifier = DefaultOutput };
            var response = _client.AdminShellRepo.GetAllAssetAdministrationShells(request);
            return response.Payload.Select(x => x.Id).ToArray();
        }

        public async Task<string[]> GetEntityComponentsAsync(string assetId)
        {
            GetAllSubmodelReferencesRpcRequest refRequest = new() { Id = Base64Converter.ToBase64(assetId), OutputModifier = DefaultOutput };
            var refResponse = await _client.AdminShell.GetAllSubmodelReferencesAsync(refRequest);
            return refResponse.Payload.Select(r => r.Keys.First().Value).ToArray();
        }

        public string[] GetEntityComponents(string assetId)
        {
            GetAllSubmodelReferencesRpcRequest refRequest = new() { Id = Base64Converter.ToBase64(assetId), OutputModifier = DefaultOutput };
            var refResponse = _client.AdminShell.GetAllSubmodelReferences(refRequest);
            return refResponse.Payload.Select(r => r.Keys.First().Value).ToArray();
        }

        public bool HasComponent(string assetId, string componentId)
        {
            return GetEntityComponents(assetId).Contains(componentId);
        }

        public async Task<bool> HasComponentAsync(string assetId, string componentId)
        {
            var components = await GetEntityComponentsAsync(assetId);
            return components.Contains(componentId);
        }

        public bool HasEntity(string id)
        {
            GetAssetAdministrationShellByIdRpcRequest request = new() { Id = Base64Converter.ToBase64(id), OutputModifier = DefaultOutput };
            var response = _client.AdminShellRepo.GetAssetAdministrationShellById(request);
            return response.StatusCode == 200;
        }

        public async Task<bool> HasEntityAsync(string id)
        {
            GetAssetAdministrationShellByIdRpcRequest request = new() { Id = Base64Converter.ToBase64(id), OutputModifier = DefaultOutput };
            var response = await _client.AdminShellRepo.GetAssetAdministrationShellByIdAsync(request);
            return response.StatusCode == 200;
        }

        public bool SetComponentProperty<T>(string id, string prop, T value)
        {
            SubmodelElementDTO property = CreateProperty(value);
            string[] path = prop.Split('.');
            property.IdShort = path.First();
            PutSubmodelElementByPathRpcRequest request = new() { SubmodelId = Base64Converter.ToBase64(id), SubmodelElement = property };
            foreach (string idShort in path) {
                request.Path.Add(new KeyDTO() { Type = KeyTypes.SubmodelElement, Value = idShort });
            }
            var response = _client.Submodel.PutSubmodelElementByPath(request);
            return response.StatusCode == 201;
        }

        public async Task<bool> SetComponentPropertyAsync<T>(string id, string prop, T value)
        {
            SubmodelElementDTO property = CreateProperty(value);
            string[] path = prop.Split('.');
            property.IdShort = path.First();
            PutSubmodelElementByPathRpcRequest request = new() { SubmodelId = Base64Converter.ToBase64(id), SubmodelElement = property };
            foreach (string idShort in path) {
                request.Path.Add(new KeyDTO() { Type = KeyTypes.SubmodelElement, Value = idShort });
            }
            var response = await _client.Submodel.PutSubmodelElementByPathAsync(request);
            return response.StatusCode == 201;
        }

        private SubmodelElementDTO CreateProperty<T>(T value) {
            string propValue = "";
            DataTypeDefXsd propType = DataTypeDefXsd.String;

            if (value is string s) { propType = DataTypeDefXsd.String; propValue = s; }
            else if (value is uint ui) { propType = DataTypeDefXsd.UnsignedInt; propValue = ui.ToString(); }
            else if (value is int i) { propType = DataTypeDefXsd.Int; propValue = i.ToString(); }
            else if (value is ulong ul) { propType = DataTypeDefXsd.UnsignedLong; propValue = ul.ToString(); }
            else if (value is long l) { propType = DataTypeDefXsd.Int; propValue = l.ToString(); }
            else if (value is ushort ush) { propType = DataTypeDefXsd.UnsignedShort; propValue = ush.ToString(); }
            else if (value is short sh) { propType = DataTypeDefXsd.Short; propValue = sh.ToString(); }
            else if (value is byte by) { propType = DataTypeDefXsd.Byte; propValue = by.ToString(); }
            else if (value is char c) { propType = DataTypeDefXsd.UnsignedByte; propValue = ((byte) c).ToString(); }
            else if (value is double d) { propType = DataTypeDefXsd.Double; propValue = d.ToString(); }
            else if (value is float f) { propType = DataTypeDefXsd.Float; propValue = f.ToString(); }
            else if (value is bool b) { propType = DataTypeDefXsd.Boolean; propValue = b.ToString(); }
            // Add more types if needed...
            else { throw new ArgumentException("The specified property type is currently not supported by the client!"); }

            return SubmodelElementFactory.Create(SubmodelElementType.Property, null, propValue, propType);
        }

        public bool CreateComponentProperty<T>(string id, string prop, T value)
        {
            if (HasComponentProperty(id, prop)) {
                return true;
            }
            SubmodelElementDTO property = CreateProperty(value);
            string[] path = prop.Split('.');
            property.IdShort = path.First();
            PostSubmodelElementByPathRpcRequest request = new() { SubmodelId = Base64Converter.ToBase64(id), SubmodelElement = property };
            foreach (string idShort in path) {
                request.Path.Add(new KeyDTO() { Type = KeyTypes.SubmodelElement, Value = idShort });
            }
            var response = _client.Submodel.PostSubmodelElementByPath(request);
            return response.StatusCode == 201;
        }

        public async Task<bool> CreateComponentPropertyAsync<T>(string id, string prop, T value)
        {
            if (await HasComponentPropertyAsync(id, prop)) {
                return true;
            }
            SubmodelElementDTO property = CreateProperty(value);
            string[] path = prop.Split('.');
            property.IdShort = path.First();
            PostSubmodelElementByPathRpcRequest request = new() { SubmodelId = Base64Converter.ToBase64(id), SubmodelElement = property };
            foreach (string idShort in path) {
                request.Path.Add(new KeyDTO() { Type = KeyTypes.SubmodelElement, Value = idShort });
            }
            var response = await _client.Submodel.PostSubmodelElementByPathAsync(request);
            return response.StatusCode == 201;
        }

        public bool HasComponentProperty(string id, string prop)
        {
            GetSubmodelElementByPathRpcRequest request = new() { SubmodelId = Base64Converter.ToBase64(id), OutputModifier = DefaultOutput };
            foreach (string idShort in prop.Split('.')) {
                request.Path.Add(new KeyDTO() { Type = KeyTypes.SubmodelElement, Value = idShort });
            }
            var response = _client.Submodel.GetSubmodelElementByPath(request);
            return response.StatusCode == 201 && response.Payload.SubmodelElementType == SubmodelElementType.Property;
        }

        public async Task<bool> HasComponentPropertyAsync(string id, string prop)
        {
            GetSubmodelElementByPathRpcRequest request = new() { SubmodelId = Base64Converter.ToBase64(id), OutputModifier = DefaultOutput };
            foreach (string idShort in prop.Split('.')) {
                request.Path.Add(new KeyDTO() { Type = KeyTypes.SubmodelElement, Value = idShort });
            }
            var response = await _client.Submodel.GetSubmodelElementByPathAsync(request);
            return response.StatusCode == 201 && response.Payload.SubmodelElementType == SubmodelElementType.Property;
        }

        private T GetProperty<T>(PropertyPayloadDTO property) {
            string value = property.Value;
            object result = null;
            switch(property.ValueType) {
                case DataTypeDefXsd.UnsignedInt: result = uint.Parse(value); break;
                case DataTypeDefXsd.Int: result = int.Parse(value); break;
                case DataTypeDefXsd.UnsignedLong: result = ulong.Parse(value); break;
                case DataTypeDefXsd.Long: result = long.Parse(value); break;
                case DataTypeDefXsd.UnsignedShort: result = ushort.Parse(value); break;
                case DataTypeDefXsd.Short: result = short.Parse(value); break;
                case DataTypeDefXsd.Byte: result = byte.Parse(value); break;
                case DataTypeDefXsd.UnsignedByte: result = (char) byte.Parse(value); break;
                case DataTypeDefXsd.Double: result = double.Parse(value); break;
                case DataTypeDefXsd.Float: result = float.Parse(value); break;
                case DataTypeDefXsd.Boolean: result = bool.Parse(value); break;
                // TODO Add more types if needed...
            }
            return (T) result;
        }

        public T GetComponentProperty<T>(string id, string prop)
        {
            GetSubmodelElementByPathRpcRequest request = new() { SubmodelId = Base64Converter.ToBase64(id) };
            foreach (string idShort in prop.Split('.')) {
                request.Path.Add(new KeyDTO() { Type = KeyTypes.SubmodelElement, Value = idShort });
            }
            var response = _client.Submodel.GetSubmodelElementByPath(request);
            if (response.StatusCode != 201 || response.Payload.SubmodelElementType != SubmodelElementType.Property) {
                throw new NullReferenceException("Property not found!");
            }
            return GetProperty<T>(response.Payload.Property);
        }

        public async Task<T> GetComponentPropertyAsync<T>(string id, string prop)
        {
            GetSubmodelElementByPathRpcRequest request = new() { SubmodelId = Base64Converter.ToBase64(id) };
            foreach (string idShort in prop.Split('.')) {
                request.Path.Add(new KeyDTO() { Type = KeyTypes.SubmodelElement, Value = idShort });
            }
            var response = await _client.Submodel.GetSubmodelElementByPathAsync(request);
            if (response.StatusCode != 201 || response.Payload.SubmodelElementType != SubmodelElementType.Property) {
                throw new NullReferenceException("Property not found!");
            }
            return GetProperty<T>(response.Payload.Property);
        }
    }

}