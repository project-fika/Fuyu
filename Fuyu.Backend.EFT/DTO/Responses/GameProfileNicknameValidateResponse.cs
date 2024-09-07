using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class GameProfileNicknameValidateResponse
    {
        [DataMember]
        public string status;
    }
}