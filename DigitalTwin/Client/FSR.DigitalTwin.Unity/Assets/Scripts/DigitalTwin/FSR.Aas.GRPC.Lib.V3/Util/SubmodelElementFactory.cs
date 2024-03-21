using System;
using UnityEngine;

namespace FSR.Aas.GRPC.Lib.V3.Util
{

    public class SubmodelElementFactory {
        public SubmodelElementDTO Create(SubmodelElementType type, params object[] args) {

            switch (type) {
                case SubmodelElementType.Property: 
                    return CreateProperty((ReferenceDTO) args[0], (string) args[1], (DataTypeDefXsd) args[2]);
            }
            Debug.LogError("Should not happen");
            return new SubmodelElementDTO();
        }

        private static SubmodelElementDTO CreateProperty(ReferenceDTO valueId, string value, DataTypeDefXsd valueType) {
            return new SubmodelElementDTO() {
                Property = new() { ValueId = valueId, Value = value, ValueType = valueType }
            };
        }
    }

} // namespace FSR.Aas.GRPC.Lib.V3.Util