using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Items
{
    [DataContract]
    public struct ItemRepairable
    {
        [DataMember]
        public float Durability;

        [DataMember]
        public float MaxDurability;
    }
}