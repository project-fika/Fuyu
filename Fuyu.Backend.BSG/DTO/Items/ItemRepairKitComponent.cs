using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemRepairKitComponent
    {
        [DataMember]
        public float Resource;
    }
}