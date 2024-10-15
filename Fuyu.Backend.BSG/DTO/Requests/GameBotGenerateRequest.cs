using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Bots;

namespace Fuyu.Backend.BSG.DTO.Requests
{
    [DataContract]
    public class GameBotGenerateRequest
    {
        [DataMember]
        public BotCondition[] conditions;
    }
}