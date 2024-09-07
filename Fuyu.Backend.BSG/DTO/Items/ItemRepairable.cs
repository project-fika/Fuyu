using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemRepairable
    {
        [DataMember]
        public float Durability;

        [DataMember]
        public float MaxDurability;
    }
}