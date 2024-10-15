using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemLockableComponent
    {
        [DataMember]
        public bool Locked;
    }
}