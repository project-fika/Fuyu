using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class ProfileSelectResponse
    {
        [DataMember]
        public string status;
    }
}