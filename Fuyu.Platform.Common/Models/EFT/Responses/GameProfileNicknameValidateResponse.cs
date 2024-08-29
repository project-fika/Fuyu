using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct GameProfileNicknameValidateResponse
    {
        [DataMember]
        public string status;
    }
}