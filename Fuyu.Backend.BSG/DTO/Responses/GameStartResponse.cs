using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class GameStartResponse
    {
        [DataMember]
        public double utc_time;
    }
}