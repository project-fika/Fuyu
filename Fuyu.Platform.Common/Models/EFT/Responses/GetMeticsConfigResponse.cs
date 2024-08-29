using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct GetMetricsConfigResponse
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