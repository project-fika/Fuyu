using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Fuyu.Platform.Common.Models.EFT.Bots;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Info
{
    [DataContract]
    public struct BotCondition
    {
        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public EBotRole Role;

        [DataMember]
        public int Limit;

        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public EBotDifficulty Difficulty;
    }
}