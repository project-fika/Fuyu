using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
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