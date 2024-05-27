using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct FriendListResponse
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