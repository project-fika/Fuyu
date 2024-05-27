using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Fuyu.Platform.Common.Models.EFT.Bots;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Info
{
    [DataContract]
    public struct BotSettings
    {
        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public EBotRole Role;

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