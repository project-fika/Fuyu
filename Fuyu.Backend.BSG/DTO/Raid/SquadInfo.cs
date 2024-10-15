using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Raid
{
    [DataContract]
    public class SquadInfo
    {
        [DataMember]
        public string Nickname;

        [DataMember]
        public string Side;

        [DataMember]
        public int Level;

        [DataMember]
        public int MemberCategory;

        [DataMember]
        public int SelectedCategory;

        [DataMember]
        public string GameVersion;

        [DataMember]
        public int SavageLockTime;

        [DataMember]
        public string SavageNickname;

        [DataMember]
        public bool hasCoopExtension;
    }
}