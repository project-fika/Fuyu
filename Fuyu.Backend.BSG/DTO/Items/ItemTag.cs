using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemTag
    {
        [DataMember]
        public int Color;

        [DataMember]
        public string Name;
    }
}