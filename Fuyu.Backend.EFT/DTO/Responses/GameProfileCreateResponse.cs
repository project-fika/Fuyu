using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class GameProfileCreateResponse
    {
        [DataMember]
        public string uid;
    }
}