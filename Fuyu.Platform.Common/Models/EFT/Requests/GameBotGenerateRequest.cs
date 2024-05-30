using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Bots;

namespace Fuyu.Platform.Common.Models.EFT.Requests
{
    [DataContract]
    public struct GameBotGenerateRequest
    {
        [DataMember]
        public BotCondition[] conditions;
    }
}