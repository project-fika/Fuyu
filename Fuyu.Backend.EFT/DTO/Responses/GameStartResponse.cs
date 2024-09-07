using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class GameStartResponse
    {
        [DataMember]
        public double utc_time;
    }
}