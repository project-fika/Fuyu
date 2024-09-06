using System.Runtime.Serialization;

namespace Fuyu.Backend.Common.DTO.Requests
{
    [DataContract]
    public class FuyuGameLoginRequest
    {
        [DataMember]
        public int AccountId;
    }
}