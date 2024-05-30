using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles.Stats;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct DamageStats
    {
        [DataMember]
        public EDamageType Type;
        
        [DataMember]
        public string SourceId;
        
        [DataMember]
        public EBodyPart? OverDamageFrom;
        
        [DataMember]
        public bool Blunt;
        
        [DataMember]
        public float ImpactsCount;
        
        [DataMember]
        public float Amount;
    }
}