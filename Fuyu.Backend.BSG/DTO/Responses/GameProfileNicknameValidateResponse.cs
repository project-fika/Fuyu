using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class GameProfileNicknameValidateResponse
    {
        [DataMember]
        public string status;
    }
}