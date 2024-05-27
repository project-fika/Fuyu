using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct CustomizationInfo
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