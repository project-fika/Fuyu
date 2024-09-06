using System.Runtime.Serialization;

namespace Fuyu.Backend.Common.DTO.Responses
{
    [DataContract]
    public class FuyuGameLoginResponse
    {
        [DataMember]
        public string SessionId;
    }
}