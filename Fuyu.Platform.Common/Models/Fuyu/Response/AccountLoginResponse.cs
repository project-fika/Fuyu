using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.Fuyu.Responses
{
    [DataContract]
    public struct AccountLoginResponse
    {
        [DataMember]
        public string SessionId;
    }
}