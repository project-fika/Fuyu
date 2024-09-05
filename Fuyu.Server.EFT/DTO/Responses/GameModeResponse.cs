using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Responses
{
    [DataContract]
    public class GameModeResponse
    {
        [DataMember]
        public string gameMode;

        [DataMember]
        public string backendUrl;
    }
}