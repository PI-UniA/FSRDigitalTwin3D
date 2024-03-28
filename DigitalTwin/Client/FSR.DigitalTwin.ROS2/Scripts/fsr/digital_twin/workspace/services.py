import grpc

from Protos.Services.AssetAdministrationShellService_pb2_grpc import AssetAdministrationShellServiceStub
from Protos.Services.AdminShellRepositoryService_pb2_grpc import AssetAdministrationShellRepositoryServiceStub
from Protos.Services.SubmodelRepositoryService_pb2_grpc import SubmodelRepositoryServiceStub
from Protos.Services.SubmodelService_pb2_grpc import SubmodelServiceStub


class AdminShellApiServiceClient:

    def __init__(self, channel : grpc.Channel) -> None:
        self._adminShell = AssetAdministrationShellServiceStub(channel)
        self._adminShellRepo = AssetAdministrationShellRepositoryServiceStub(channel)
        self._submodel = SubmodelServiceStub(channel)
        self._submodelRepo = SubmodelRepositoryServiceStub(channel)
    
    @property
    def adminShell(self) -> AssetAdministrationShellServiceStub:
        return self._adminShell

    @property
    def adminShellRepo(self) -> AssetAdministrationShellRepositoryServiceStub:
        return self._adminShellRepo
    
    @property
    def submodel(self) -> SubmodelServiceStub:
        return self._submodel

    @property
    def submodelRepo(self) -> SubmodelRepositoryServiceStub:
        return self._submodelRepo