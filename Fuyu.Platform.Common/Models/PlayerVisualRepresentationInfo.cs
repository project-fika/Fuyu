using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct PlayerVisualRepresentationInfo
    {
        [DataMember]
        public string Nickname;
        [DataMember]
        public EPlayerSide Side;
        [DataMember]
        public int Level;
        [DataMember]
        public EMemberCategory MemberCategory;
        [DataMember]
        public double SavageLockTime;
        [DataMember]
        public string SavageNickname;
        [DataMember]
        public string GameVersion;
        [DataMember]
        public bool HasCoopExtension;
    }
}