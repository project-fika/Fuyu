using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Responses
{
    [DataContract]
    public class ProfileSelectResponse
    {
        [DataMember]
        public string status;
    }
}