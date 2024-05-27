using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct GameLogoutResponse
    {
        [DataMember]
        public string status;
    }
}