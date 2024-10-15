using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class HideoutSettingsResponse
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