using System;
using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct UpdatableChatMember
    {
        [DataMember]
        public String Id;
        
        [DataMember]
        public String AccountId;
        
        [DataMember]
        public UpdatableChatMemberInfo MemberInfo;
    }
}