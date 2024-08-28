using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct GameModeResponse
    {
        [DataMember]
        public string gameMode;
        public string backendUrl;
    }
}