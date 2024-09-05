using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Items
{
    [DataContract]
    public class ItemMedKit
    {
        [DataMember]
        public int HpResource;
    }
}