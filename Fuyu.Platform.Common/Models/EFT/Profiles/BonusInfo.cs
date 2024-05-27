using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Fuyu.Platform.Common.Models.EFT.Profiles.Bonusses;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct BonusInfo
    {
        [DataMember]
        public string id;

        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public EBonusType type;

        [DataMember]
        public string templateId;
    }
}