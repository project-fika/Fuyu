using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Locations
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