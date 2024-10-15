using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemTagComponent
    {
        [DataMember]
        public int Color;

        [DataMember]
        public string Name;
    }
}