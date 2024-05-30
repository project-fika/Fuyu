using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Bots;
using Newtonsoft.Json.Converters;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct BotSettings
    {
        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public WildSpawnType Role;

        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public EBotDifficulty BotDifficulty;

        [DataMember]
        public int Experience;

        [DataMember]
        public float StandingForKill;

        [DataMember]
        public float AggressorBonus;
    }
}