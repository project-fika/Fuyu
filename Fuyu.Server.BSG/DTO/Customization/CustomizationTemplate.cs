using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Customization
{
    [DataContract]
    public class CustomizationTemplate
    {
        [DataMember]
        public string _id;

        [DataMember]
        public string _name;

        [DataMember]
        public string _parent;

        [DataMember]
        public string _type;

        [DataMember]
        public CustomizationProperties _props;

        [DataMember]
        public string _proto;
    }
}