using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Profiles.Stats
{
    [DataContract]
    public class DamageHistory
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