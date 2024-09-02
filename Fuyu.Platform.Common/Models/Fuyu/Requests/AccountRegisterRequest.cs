using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.Fuyu.Requests
{
    [DataContract]
    public struct AccountRegisterRequest
    {
        [DataMember]
        public string Username;

        [DataMember]
        public string Password;

        [DataMember]
        public string Edition;
    }
}