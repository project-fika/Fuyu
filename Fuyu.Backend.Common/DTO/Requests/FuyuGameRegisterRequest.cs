using System.Runtime.Serialization;

namespace Fuyu.Backend.Common.DTO.Requests
{
    [DataContract]
    public class FuyuGameRegisterRequest
    {
        [DataMember]
        public string Edition;
    }
}