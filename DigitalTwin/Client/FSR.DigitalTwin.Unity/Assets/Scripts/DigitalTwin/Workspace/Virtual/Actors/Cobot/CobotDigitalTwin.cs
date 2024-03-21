using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FSR.Aas.GRPC.Lib.V3.Services;
using FSR.Aas.GRPC.Lib.V3.Services.SubmodelRepository;
using FSR.DigitalTwin.Unity.Workspace.Digital;
using FSR.DigitalTwin.Unity.Workspace.Digital.Interfaces;
using UnityEngine;


namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Actors {

    /// <summary>
    /// A cobot is a simple kinematic (robot arm) consisting of (for now) rotational joints.
    /// Using a set of joints, the kinematic can be controlled and transformed internally and externally
    /// </summary>
    public class CobotDigialTwin : MonoBehaviour, IDigitalTwinActor
    {
        [SerializeField] private Cobot cobot;
        [SerializeField] private string operationalSubmodelId = "aHR0cHM6Ly93d3cuaHMtZW1kZW4tbGVlci5kZS9pZHMvc20vNjQ5NF8yMTYyXzUwMzJfMjgxMw";

        public DigitalWorkspace DigitalWorkspace => DigitalWorkspace.Instance;

        private async Task<bool> AssertOperationalSubmodelAsync() {
            var aasApi = DigitalWorkspace.ApiBridge.AasApiClient;
            GetSubmodelByIdRpcRequest request = new() {
                Id = operationalSubmodelId,
                OutputModifier = new OutputModifier() {
                    Limit = 1, Level = OutputLevel.Core, Content = OutputContent.Reference, 
                    Extent = OutputExtent.WithoutBlobValue
                }
            };
            var response = await aasApi.SubmodelRepo.GetSubmodelByIdAsync(request);
            Debug.Log("Requested Operational submodel - Status " + response.StatusCode);
            return response.StatusCode == 201;
        }

        public int PullDataAndApply()
        {
            throw new NotImplementedException();
        }

        public async Task<int> PullDataAndApplyAsync()
        {
            if (!await AssertOperationalSubmodelAsync()) {
                return -1;
            }
            return 0;
        }

        public int PushData()
        {
            throw new NotImplementedException();
        }

        public Task<int> PushDataAsync()
        {
            throw new NotImplementedException();
        }

        async void Start() {
            await AssertOperationalSubmodelAsync();
        }

    }

} // END namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Actors 
