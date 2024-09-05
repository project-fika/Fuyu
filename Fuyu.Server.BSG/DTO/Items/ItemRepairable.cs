using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Items
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