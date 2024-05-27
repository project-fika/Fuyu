using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Hideout;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Hideout
{
    [DataContract]
    public struct HideoutAreaInfo
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
        public bool constructing;

        // TODO: proper type
        [DataMember]
        public object[] slots;

        [DataMember]
        public string lastRecipe;
    }
}