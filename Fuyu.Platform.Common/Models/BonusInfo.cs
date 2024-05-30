using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT;
using Newtonsoft.Json.Converters;

namespace Fuyu.Platform.Common.Models
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