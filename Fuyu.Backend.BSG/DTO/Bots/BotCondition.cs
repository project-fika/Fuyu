using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Fuyu.Backend.BSG.DTO.Bots
{
    [DataContract]
    public class BotCondition
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