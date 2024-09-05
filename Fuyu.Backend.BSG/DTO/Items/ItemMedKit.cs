using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemMedKit
    {
        [DataMember]
        public int HpResource;
    }
}