using Fuyu.Backend.BSG.DTO.Common;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemBuff
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