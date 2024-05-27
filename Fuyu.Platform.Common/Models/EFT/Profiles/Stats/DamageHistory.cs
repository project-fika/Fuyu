using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Stats
{
    [DataContract]
    public struct DamageHistory
    {
        [DataMember]
        public string LethalDamagePart;

        // TODO: proper type
        public object LethalDamage;
    }
}