using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.InventoryLogic;
using Fuyu.Platform.Common.Models.EFT.Profiles;

namespace Fuyu.Platform.Common.Models.EFT
{
    // Assembly-CSharp.dll: EFT.Profile
    [DataContract]
    public struct Profile
    {
        [DataMember]
        public string _id;

        [DataMember]
        public int aid;

        [DataMember]
        public string savage;

        [DataMember]
        public ProfileInfo Info;

        [DataMember]
        public CustomizationInfo Customization;

        [DataMember]
        public HealthInfo Health;

        [DataMember]
        public InventoryInfo Inventory;

        [DataMember]
        public SkillInfo Skills;

        [DataMember]
        public StatsInfo Stats;

        [DataMember]
        public Dictionary<string, bool> Encyclopedia;

        [DataMember]
        public Dictionary<string, ConditionCounter> TaskConditionCounters;

        [DataMember]
        public InsuredItem[] InsuredItems;

        [DataMember]
        public HideoutInfo? Hideout;

        [DataMember]
        public BonusInfo[] Bonuses;

        [DataMember]
        public NotesInfo Notes;

        [DataMember]
        public QuestInfo[] Quests;

        [DataMember]
        public Dictionary<string,int> Achievements;

        [DataMember]
        public RagfairInfo RagfairInfo;

        [DataMember]
        public string[] WishList;

        [DataMember]
        public Dictionary<string, TraderInfo> TradersInfo;

        [DataMember]
        public UnlockedInfo UnlockedInfo;
    }
}