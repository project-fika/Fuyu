using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Stats
{
    [DataContract]
    public struct DamageHistory
    {
        [DataMember]
        public string LethalDamagePart;

        // TODO: proper type
        [DataMember]
        public object LethalDamage;

        // TODO: proper type
        [DataMember]
        public object[] BodyParts;
    }
}