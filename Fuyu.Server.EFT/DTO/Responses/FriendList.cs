using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Responses
{
    [DataContract]
    public class FriendListResponse
    {
        // TODO: proper type
        [DataMember]
        public object[] Friends;

        // TODO: proper type
        [DataMember]
        public object[] Ignore;

        // TODO: proper type
        [DataMember]
        public object[] InIgnoreList;
    }
}