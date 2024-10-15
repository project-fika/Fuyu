using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Locations
{
    [DataContract]
    public class MaxItemCount
    {
        [DataMember]
        public string TemplateId;

        [DataMember]
        public int Value;
    }
}