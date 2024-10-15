using System;
using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles.Info;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.BSG.DTO.Items
{
    [DataContract]
    public class ItemDogtagComponent
    {
        // AccountId is the string version of the pmc.aid
        [DataMember]
        public string AccountId;

        [DataMember]
        public MongoId ProfileId;

        [DataMember]
        public string Nickname;

        [DataMember]
        public EPlayerSide Side;

        [DataMember]
        public int Level;

        [DataMember]
        public DateTime Time;

        [DataMember]
        public string Status;

		// AccountId is the string version of the pmc.aid
		[DataMember]
        public string KillerAccountId;

        [DataMember]
        public MongoId KillerProfileId;

        [DataMember]
        public string KillerName;

        [DataMember]
        public string WeaponName;

        // Whenever you carry out your own group member's dogtag it sells for 1 ruble
        [DataMember]
        public bool CarriedByGroupMember;
    }
}