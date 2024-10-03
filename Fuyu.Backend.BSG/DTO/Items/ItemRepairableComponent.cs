using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemRepairableComponent
    {
        [DataMember]
        public float Durability;

        [DataMember]
        public float MaxDurability;
    }
}