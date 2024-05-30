using System;
using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Bots;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct VictimStats
    {
        [DataMember]
        public string AccountId;
        
        [DataMember]
        public string ProfileId;
        
        [DataMember]
        public string Name;
        
        [DataMember]
        public EPlayerSide Side;
        
        [DataMember]
        public TimeSpan Time;
        
        [DataMember]
        public int Level;
        public EBodyPart BodyPart;
        
        [DataMember]
        public string Weapon;
        
        [DataMember]
        public float Distance;
        
        [DataMember]
        public WildSpawnType Role;
    }
}