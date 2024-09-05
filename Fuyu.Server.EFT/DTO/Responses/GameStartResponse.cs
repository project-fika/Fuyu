using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Responses
{
    [DataContract]
    public class GameStartResponse
    {
        [DataMember]
        public double utc_time;
    }
}