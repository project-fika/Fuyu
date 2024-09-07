using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Hideout;

namespace Fuyu.Backend.BSG.DTO.Profiles.Hideout
{
    [DataContract]
    public class HideoutAreaInfo
    {
        [DataMember]
        public EAreaType type;

        [DataMember]
        public int level;

        [DataMember]
        public bool active;

        // TODO: proper type
        [DataMember]
        public bool passiveBonusesEnabled;

        [DataMember]
        public long completeTime;

        [DataMember]
        public bool conclassing;

        // TODO: proper type
        [DataMember]
        public object[] slots;

        [DataMember]
        public string lastRecipe;
    }
}