import grpc
from fsr.digital_twin.abc.workspace import *
from fsr.digital_twin.workspace.services import AdminShellApiServiceClient

from Protos.Services.AdminShellRepositoryService_pb2 import GetAllAssetAdministrationShellsRpcRequest

class DigitalWorkspaceBridge:

    def __init__(self):
        self._address = "127.0.0.1"
        self._port = 5001
        self._rpcChannel : grpc.Channel = None
        self._apiClient : AdminShellApiServiceClient = None
    
    def connect_to_api(self, addr : str, port : int):
        self._address = addr
        self._port = port
        self._rpcChannel = grpc.insecure_channel(self._address + ":" + str(self._port))
        self._apiClient = AdminShellApiServiceClient(self._rpcChannel)

        # For quick testing...
        request = GetAllAssetAdministrationShellsRpcRequest()
        request.outputModifier.cursor = ""
        request.outputModifier.limit = 32
        request.outputModifier.level = 0
        request.outputModifier.content = 0
        request.outputModifier.extent = 0
        shells = self._apiClient.adminShellRepo.GetAllAssetAdministrationShells(request)
        print("[Client]: Recieved Admin Shells: " + str(shells))


class DigitalWorkspace(Workspace):
    def __init__(self, addr : str = "127.0.0.1", port : int = 5001):
        self._addr = addr
        self._port = port
        self._apiBridge : DigitalWorkspaceBridge = DigitalWorkspaceBridge()
    
    def _get_kind(self):
        return WorkspaceKind.DIGITAL
    
    def connect(self):
        self._apiBridge.connect_to_api(self._addr, self._port)

    