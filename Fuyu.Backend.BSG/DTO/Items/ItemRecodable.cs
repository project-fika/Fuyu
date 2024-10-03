using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemRecodable
    {
        [DataMember]
        public bool IsEncoded;
    }
}