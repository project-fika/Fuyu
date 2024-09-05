using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Requests
{
    [DataContract]
    public class GameProfileNicknameValidateRequest
    {
        [DataMember]
        public string nickname;
    }
}