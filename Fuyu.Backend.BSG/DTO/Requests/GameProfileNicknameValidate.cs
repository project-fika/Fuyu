using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Requests
{
    [DataContract]
    public class GameProfileNicknameValidateRequest
    {
        [DataMember]
        public string nickname;
    }
}