using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Fuyu.Backend.BSG.DTO.Profiles.Bonusses;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class BonusInfo
    {
        [DataMember]
        public MongoId id;

        [DataMember(EmitDefaultValue = false)]
        public string icon;

        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public EBonusType type;

        [DataMember]
        public float value;

        [DataMember(EmitDefaultValue = false)]
        public MongoId templateId;

        [DataMember]
        public bool passive;

        [DataMember]
        public bool visible;

		[DataMember(EmitDefaultValue = false)]
		public bool production;

        [DataMember(EmitDefaultValue = false)]
        public MongoId[] filter;
    }
}