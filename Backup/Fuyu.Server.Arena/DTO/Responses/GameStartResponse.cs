using System.Runtime.Serialization;

namespace Fuyu.Server.Arena.DTO.Responses
{
    [DataContract]
    public class GameStartResponse
    {
        [DataMember]
        public double utc_time;
    }
}