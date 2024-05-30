using System;
using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct FriendListResponse
    {
        [DataMember]
        public UpdatableChatMember[] Friends;

        [DataMember]
        public String[] Ignore;

        [DataMember]
        public String[] InIgnoreList;
    }
}