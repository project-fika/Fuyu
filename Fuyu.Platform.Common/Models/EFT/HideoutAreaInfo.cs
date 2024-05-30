using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Hideout;

namespace Fuyu.Platform.Common.Models.EFT
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

        [DataMember]
        public bool passiveBonusesEnabled;

        [DataMember]
        public long completeTime;

        [DataMember]
        public bool constructing;

        [DataMember]
        public Bonuses[] bonuses;
        
        [DataMember]
        public ItemsWithinSlots[] slots;

        [DataMember]
        public string lastRecipe;
    }
}