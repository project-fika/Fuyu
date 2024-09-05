using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Responses
{
    [DataContract]
    public class GameProfileCreateResponse
    {
        [DataMember]
        public string uid;
    }
}