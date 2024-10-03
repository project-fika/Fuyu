using Fuyu.Backend.BSG.DTO.Profiles.Info;
using System;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
    [DataContract]
    public class ItemDogtag
    {
        [DataMember]
        public string AccountId = "";

        [DataMember]
        public string ProfileId = "";

        [DataMember]
        public string Nickname = "";

        [DataMember]
        public EPlayerSide Side;

        [DataMember]
        public int Level;

        [DataMember]
        public DateTime Time;

        [DataMember]
        public string Status = "";

        [DataMember]
        public string KillerAccountId = "";

        [DataMember]
        public string KillerProfileId = "";

        [DataMember]
        public string KillerName = "";

        [DataMember]
        public string WeaponName = "";

        [DataMember]
        public bool CarriedByGroupMember;
    }
}