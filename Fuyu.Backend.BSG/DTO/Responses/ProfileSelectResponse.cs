using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class ProfileSelectResponse
    {
        [DataMember]
        public string status;
    }
}