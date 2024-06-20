using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using FSR.Aas.GRPC.Lib.V3;
using FSR.Aas.GRPC.Lib.V3.Services;
using FSR.Aas.GRPC.Lib.V3.Services.SubmodelService;
using FSR.DigitalTwin.Unity.Workspace.Digital;
using FSR.DigitalTwin.Unity.Workspace.Virtual.Sensors;
using FSR.DigitalTwin.Util;
using FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection;
using Google.Protobuf;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Actors {

    /// <summary>
    /// A cobot is a simple kinematic (robot arm) consisting of (for now) rotational joints.
    /// Using a set of joints, the kinematic can be controlled and transformed internally and externally
    /// </summary>
    public class CobotKinematic : DigitalTwinComponent
    {
        [SerializeField] private List<JointSensorSource> joints;
        [SerializeField] private int sensorId = 0;

        public JointSensorSource[] Joints => joints.ToArray();
        public bool IsListening { get; set; } = false;

        private string _streamName = ""; // TODO Get this value from AAS 

        public override async Task<int> OnPushDataAsync()
        {
            if (!await HasConnectionAsync()) {
                Debug.LogError("[Client]: Missing SensorStream submodel!");
                return -1;
            }
            var data = GetJointData();
            UpdatePropertyRequest request = new() { Name = _streamName, Value = data };
            var response = await DigitalWorkspace.ApiBridge.Layer.Streaming.UpdatePropertyAsync(request);
            return response.Success ? 0 : -1;
        }

        public override async Task<int> OnSynchronizeDataAsync()
        {
            if (!await HasConnectionAsync()) {
                Debug.LogError("[Client]: Missing SensorStream submodel!");
                return -1;
            }
            GetPropertyRequest request = new() { Name = _streamName };
            var response = await DigitalWorkspace.ApiBridge.Layer.Streaming.GetPropertyAsync(request);
            if (!response.Success) {
                return -1;
            }
            byte[] data = response.Value.ToByteArray();
            float[] jointRotations = new float[data.Length / 4];
            for (int i = 0; i < jointRotations.Length; i++) {
                if (!BitConverter.IsLittleEndian) {
                    Array.Reverse(data, i * 4, 4);
                }
                jointRotations[i] = BitConverter.ToSingle(data, i * 4);
            }
            for (int i = 0; i < joints.Count; i++) {
                JointSensorSource joint = joints[i];
                if (joint.JointType == EJointType.REVOLUTE) {
                    float z = jointRotations[i];
                    (joint as RevoluteJointSensorSource).JointBody.SetDriveTarget(ArticulationDriveAxis.X, z);
                }
            }
            return 0;
        }

        private ByteString GetJointData() {
            float[] jointRotations = new float[joints.Count];
            for (int i = 0; i < joints.Count; i++) {
                JointSensorSource joint = joints[i];
                if (joint.JointType == EJointType.REVOLUTE) {
                    RevoluteJointSensorSource rotationalJoint = joint as RevoluteJointSensorSource;
                    jointRotations[i] = rotationalJoint.Z.Value;
                }
            }
            byte[] memory = new byte[jointRotations.Length * sizeof(float)];
            Buffer.BlockCopy(jointRotations, 0, memory, 0, memory.Length);

            float[] __reconstr = new float[memory.Length / 4];
            for (int i = 0; i < jointRotations.Length; i++) {
                if (!BitConverter.IsLittleEndian) {
                    Array.Reverse(memory, i * 4, 4);
                }
                __reconstr[i] = BitConverter.ToSingle(memory, i * 4);
            }

            return ByteString.CopyFrom(memory);
        }

        private async Task<string> GetStreamNameAsync() {
            var submodel = await GetSubmodelAsync();
            GetSubmodelElementByPathRpcRequest request = new() {
                SubmodelId = Base64Converter.ToBase64(SubmodelId),
                OutputModifier = new OutputModifier() {
                    Level = OutputLevel.Deep, Content = OutputContent.Normal, Cursor = "", 
                    Extent = OutputExtent.WithoutBlobValue, Limit = 16
                }
            };
            request.Path.Add(new KeyDTO { Type = KeyTypes.SubmodelElementCollection, Value = "Streams" });
            request.Path.Add(new KeyDTO { Type = KeyTypes.SubmodelElementCollection, Value = "" + sensorId });
            request.Path.Add(new KeyDTO { Type = KeyTypes.Property, Value = "Name" });
            var response = await DigitalWorkspace.ApiBridge.AasApi.Submodel.GetSubmodelElementByPathAsync(request);
            if (response.StatusCode >= 400) {
                Debug.LogError("[Client]: Unable to receive orientation!");
            }
            return response.Payload.Property.Value;
        }

        void Start() {
            DigitalWorkspace.ApiBridge.ObserveConnected.Subscribe(async _ => {
                _streamName = await GetStreamNameAsync();
                var prop = await DigitalWorkspace.ApiBridge.Layer.Streaming.GetPropertyAsync(new GetPropertyRequest() { Name = _streamName });
                if (!prop.Success) {
                    Debug.Log("[Client]: Opening stream for joint sensor data");
                    await DigitalWorkspace.ApiBridge.Layer.Streaming.CreatePropertyAsync(
                        new CreatePropertyRequest() { Name = _streamName, InitialValue = GetJointData() });
                }
                else {
                    Debug.Log("[Client]: Found joint data!");
                }
                })
            .AddTo(this);

            Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
                .Where(_ => DigitalWorkspace.ApiBridge.IsConnected)
                .Subscribe(async _ =>  { 
                    if (IsListening) { 
                        await OnSynchronizeDataAsync(); 
                    } else {
                        await OnPushDataAsync();
                    } 
                })
                .AddTo(this);
        }
    }
}