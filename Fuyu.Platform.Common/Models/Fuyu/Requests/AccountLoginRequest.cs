using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.Fuyu.Requests
{
    [DataContract]
    public struct AccountLoginRequest
    {
        [DataMember]
        public string Username;

        [DataMember]
        public string Password;
    }
}