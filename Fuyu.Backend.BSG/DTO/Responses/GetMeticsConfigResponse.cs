using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class GetMetricsConfigResponse
    {
        [DataMember]
        public int[] Keys;

        [DataMember]
        public int[] NetProcessingBins;

        [DataMember]
        public int[] RenderBins;

        [DataMember]
        public int[] GameUpdateBins;

        [DataMember]
        public int MemoryMeasureInterval;

        [DataMember]
        public int[] PauseReasons;
    }
}