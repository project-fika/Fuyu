using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Responses
{
    [DataContract]
    public class GameProfileNicknameValidateResponse
    {
        [DataMember]
        public string status;
    }
}