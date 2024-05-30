using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct UpdatableChatMemberInfo
    {
        [DataMember]
        public string Nickname;
        
        [DataMember]
        public EChatMemberSide Side;
        
        [DataMember]
        public int Level;
        
        [DataMember]
        public EMemberCategory MemberCategory;
        
        [DataMember]
        public bool Ignored;
        
        [DataMember]
        public bool Banned;
    }
}