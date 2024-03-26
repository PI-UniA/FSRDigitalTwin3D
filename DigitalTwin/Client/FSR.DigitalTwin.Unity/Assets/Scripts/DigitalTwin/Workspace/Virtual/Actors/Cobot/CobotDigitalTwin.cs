using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FSR.Aas.GRPC.Lib.V3;
using FSR.Aas.GRPC.Lib.V3.Services;
using FSR.Aas.GRPC.Lib.V3.Services.SubmodelRepository;
using FSR.Aas.GRPC.Lib.V3.Services.SubmodelService;
using FSR.Aas.GRPC.Lib.V3.Util;
using FSR.DigitalTwin.Unity.Workspace.Digital;
using FSR.DigitalTwin.Unity.Workspace.Digital.Interfaces;
using FSR.DigitalTwin.Unity.Workspace.Virtual.Sensors;
using UniRx;
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
        [SerializeField] private bool IsListening = true;

        private readonly SubmodelElementFactory submodelElementFactory = new();

        public DigitalWorkspace DigitalWorkspace => DigitalWorkspace.Instance;

        private async Task<bool> AssertOperationalSubmodelAsync() {
            var aasApi = DigitalWorkspace.ApiBridge.AasApiClient;
            GetSubmodelByIdRpcRequest request = new() {
                Id = operationalSubmodelId,
                OutputModifier = new OutputModifier() {
                    Level = OutputLevel.Core, Content = OutputContent.Reference, Cursor = "", 
                    Extent = OutputExtent.WithoutBlobValue, Limit = 1
                }
            };
            var response = await aasApi.SubmodelRepo.GetSubmodelByIdAsync(request);
            Debug.Log("Requested Operational submodel - Status " + response.StatusCode);
            return response.StatusCode == 200;
        }

        private SubmodelElementDTO CreateJointOrientationSubmodelElement() {
            List<SubmodelElementDTO> jointProperties = new();
            for (int i = 0; i < cobot.Joints.Length; i++) {
                JointSensorSource joint = cobot.Joints[i];
                if (joint.JointType == EJointType.ROTATIONAL_JOINT) {
                    RotationalJoint rotationalJoint = joint as RotationalJoint;
                    var prop = submodelElementFactory.Create(SubmodelElementType.Property, null, rotationalJoint.transform.localEulerAngles.z, DataTypeDefXsd.Float);
                    prop.IdShort = "joint_" + i + "_z";
                    jointProperties.Add(prop);
                }
            }
            var jointPropertyCollection = submodelElementFactory.Create(SubmodelElementType.SubmodelElementCollection, jointProperties);
            jointPropertyCollection.IdShort = "orientation_parameters";
            jointPropertyCollection.Description.Add(new LangStringDTO() { Language = "en", Text = "Orientation parameters of joints"});
            jointPropertyCollection.DisplayName.Add(new LangStringDTO() { Language = "en", Text = "Orientation Parameters"});

            return jointPropertyCollection;
        }

        public int OnSynchronizeData()
        {
            throw new NotImplementedException();
        }

        public async Task<int> OnSynchronizeDataAsync()
        {
            if (!await AssertOperationalSubmodelAsync()) {
                Debug.LogError("[Client]: Missing Operational submodel!");
                return -1;
            }
            GetSubmodelElementByPathRpcRequest request = new() {
                SubmodelId = operationalSubmodelId,
                OutputModifier = new OutputModifier() {
                    Level = OutputLevel.Deep, Content = OutputContent.Normal, Cursor = "", 
                    Extent = OutputExtent.WithoutBlobValue, Limit = 16
                }
            };
            request.Path.Add(new KeyDTO { Type = KeyTypes.SubmodelElementCollection, Value = "orientation_parameters" });
            var response = await DigitalWorkspace.ApiBridge.AasApiClient.Submodel.GetSubmodelElementByPathAsync(request);
            if (response.StatusCode >= 400) {
                Debug.LogError("[Client]: Unable to receive orientation!");
            }

            Hashtable jointProperties = new();
            foreach (SubmodelElementDTO sme in response.Payload.SubmodelElementCollection.Value) {
                jointProperties[sme.IdShort] = sme;
            }

            for (int i = 0; i < cobot.Joints.Length; i++) {
                JointSensorSource joint = cobot.Joints[i];
                if (joint.JointType == EJointType.ROTATIONAL_JOINT) {
                    if (!jointProperties.ContainsKey("joint_" + i + "_z")) 
                        continue;
                    SubmodelElementDTO sme = (SubmodelElementDTO) jointProperties["joint_" + i + "_z"];
                    float z = float.Parse(sme.Property.Value);
                    var euler = joint.transform.localEulerAngles;
                    euler.z = z;
                    joint.transform.localEulerAngles = euler;
                }
            }

            return 0;
        }

        public int OnPushData()
        {
            throw new NotImplementedException();
        }

        public async Task<int> OnPushDataAsync()
        {
            if (!await AssertOperationalSubmodelAsync()) {
                Debug.LogError("[Client]: Missing Operational submodel!");
                return -1;
            }
            PutSubmodelElementByPathRpcRequest request = new() {
                SubmodelId = operationalSubmodelId,
                SubmodelElement = CreateJointOrientationSubmodelElement(),
            };
            request.Path.Add(new KeyDTO { Type = KeyTypes.SubmodelElementCollection, Value = "orientation_parameters" });
            var response = await DigitalWorkspace.ApiBridge.AasApiClient.Submodel.PutSubmodelElementByPathAsync(request);
            if (response.StatusCode >= 400) {
                Debug.LogError("[Client]: Unable to upload orientation!");
            }
            return response.StatusCode;
        }

        async void Start() {
            if (!await AssertOperationalSubmodelAsync()) {
                Debug.LogError("[Client]: Missing Operational submodel! Cannot upload inital joint values!");
                return;
            }
            PostSubmodelElementRpcRequest request = new() {
                SubmodelId = operationalSubmodelId,
                SubmodelElement = CreateJointOrientationSubmodelElement()
            };
            var response = await DigitalWorkspace.ApiBridge.AasApiClient.Submodel.PostSubmodelElementAsync(request);
            if (response.StatusCode == 403) {
                Debug.Log("[Client]: Initial joint orientation data already present...");
            }

            if (IsListening) {
                Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
                    .Subscribe(async _ => await OnSynchronizeDataAsync())
                    .AddTo(this);
            }
            else {
                Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
                    .Subscribe(async _ => await OnPushDataAsync())
                    .AddTo(this);
            }

        }
    }

} // END namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Actors 
