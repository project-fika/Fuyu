using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles.Info;
using Fuyu.Backend.EFT.DTO.Bots;

namespace Fuyu.Backend.EFT.DTO.Requests
{
    [DataContract]
    public class GameBotGenerateRequest
    {
        [DataMember]
        public BotCondition[] conditions;
    }
}