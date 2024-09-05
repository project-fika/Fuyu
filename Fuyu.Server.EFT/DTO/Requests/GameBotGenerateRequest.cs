using System.Runtime.Serialization;
using Fuyu.Server.BSG.DTO.Profiles.Info;
using Fuyu.Server.EFT.DTO.Bots;

namespace Fuyu.Server.EFT.DTO.Requests
{
    [DataContract]
    public class GameBotGenerateRequest
    {
        [DataMember]
        public BotCondition[] conditions;
    }
}