using System.Runtime.Serialization;

namespace Fuyu.Server.Arena.DTO.Responses
{
    [DataContract]
    public class GameKeepaliveResponse
    {
        [DataMember]
        public string msg;

        [DataMember]
        public double utc_time;
    }
}