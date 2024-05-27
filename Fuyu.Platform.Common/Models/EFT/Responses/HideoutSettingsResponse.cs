using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct HideoutSettingsResponse
    {
        [DataMember]
        public double generatorSpeedWithoutFuel;

        [DataMember]
        public double generatorFuelFlowRate;

        [DataMember]
        public double airFilterUnitFlowRate;

        [DataMember]
        public double gpuBoostRate;
    }
}