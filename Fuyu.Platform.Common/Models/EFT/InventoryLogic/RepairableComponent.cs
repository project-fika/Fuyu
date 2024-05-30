using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.InventoryLogic
{
    [DataContract]
    public struct RepairableComponent
    {
        [DataMember]
        public float Durability;

        [DataMember]
        public float MaxDurability;
    }
}