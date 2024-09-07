using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class CustomizationInfo
    {
        [DataMember]
        public string Head;

        [DataMember]
        public string Body;

        [DataMember]
        public string Feet;

        [DataMember]
        public string Hands;
    }
}