using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Fuyu.Server.BSG.DTO.Bots;

namespace Fuyu.Server.EFT.DTO.Bots
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