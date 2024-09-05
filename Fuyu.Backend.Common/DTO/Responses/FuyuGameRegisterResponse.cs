using System.Runtime.Serialization;

namespace Fuyu.Backend.Common.DTO.Responses
{
    [DataContract]
    public class FuyuGameRegisterResponse
    {
        [DataMember]
        public int AccountId;
    }
}