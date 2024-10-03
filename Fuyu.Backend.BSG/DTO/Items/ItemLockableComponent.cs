using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemLockableComponent
    {
        [DataMember]
        public bool Locked;
    }
}