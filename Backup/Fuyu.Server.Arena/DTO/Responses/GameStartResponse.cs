using System.Runtime.Serialization;

namespace Fuyu.Backend.Arena.DTO.Responses
{
    [DataContract]
    public class GameStartResponse
    {
        [DataMember]
        public double utc_time;
    }
}