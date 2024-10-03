using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemLockable
    {
        [DataMember]
        public bool Locked;
    }
}