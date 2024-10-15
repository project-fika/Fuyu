using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class GameProfileCreateResponse
    {
        [DataMember]
        public string uid;
    }
}