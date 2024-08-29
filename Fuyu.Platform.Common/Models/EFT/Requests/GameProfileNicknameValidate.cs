using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Requests
{
    [DataContract]
    public struct GameProfileNicknameValidateRequest
    {
        [DataMember]
        public string nickname;
    }
}