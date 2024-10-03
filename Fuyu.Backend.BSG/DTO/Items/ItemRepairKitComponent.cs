using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemRepairKitComponent
    {
        [DataMember]
        public float Resource;
    }
}