using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Fuyu.Platform.Common.Models.EFT.Bots
{
    [DataContract]
    public struct BotCondition
    {
        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public WildSpawnType Role;

        [DataMember]
        public int Limit;

        [DataMember]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))] 
        public EBotDifficulty Difficulty;
    }
}