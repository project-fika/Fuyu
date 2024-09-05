using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Fuyu.Server.BSG.DTO.Profiles.Bonusses;

namespace Fuyu.Server.BSG.DTO.Profiles
{
    [DataContract]
    public class BonusInfo
    {
        [DataMember]
        public string id;

        [DataMember(EmitDefaultValue = true)]
        public string icon;

        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public EBonusType type;

        [DataMember]
        public float value;

        [DataMember(EmitDefaultValue = true)]
        public string templateId;

        [DataMember]
        public bool passive;

        [DataMember]
        public bool visible;

        [DataMember]
        public bool production;

        [DataMember(EmitDefaultValue = true)]
        public string[] filter;
    }
}