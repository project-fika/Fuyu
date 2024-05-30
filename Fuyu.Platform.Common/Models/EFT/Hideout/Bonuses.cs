using System;
using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.MongoDB;

namespace Fuyu.Platform.Common.Models.EFT.Hideout
{
    [DataContract]
    public struct Bonuses
    {
        [DataMember]
        public MongoID id;
        
        [DataMember]
        public double value;
        
        [DataMember]
        public EBonusType @type;
        
        [DataMember]
        public bool visible;
        
        [DataMember]
        public bool passive;
        
        [DataMember]
        public bool production;
        
        [DataMember]
        public string icon;
    }
}