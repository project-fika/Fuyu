using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles.Stats;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct DamageHistory
    {
        [DataMember]
        public string LethalDamagePart;

        [DataMember]
        public DamageStats LethalDamage;

        [DataMember]
        public Dictionary<EBodyPart, List<DamageStats>> BodyParts;
    }
}