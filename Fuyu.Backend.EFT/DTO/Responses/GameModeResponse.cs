using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
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