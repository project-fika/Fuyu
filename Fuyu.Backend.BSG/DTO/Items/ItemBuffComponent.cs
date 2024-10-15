using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Common;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemBuffComponent
    {
        [DataMember(Name = "buffType")]
        public ERepairBuffType BuffType { get; set; }

        [DataMember(Name = "buffRarity")]
        public EBuffRarity BuffRarity { get; set; }

        [DataMember(Name = "thresholdDurability")]
        public double ThresholdDurability { get; set; }

        [DataMember(Name = "value")]
        public double Value { get; set; }
    }
}