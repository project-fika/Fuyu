using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemRecodableComponent
    {
        [DataMember]
        public bool IsEncoded;
    }
}