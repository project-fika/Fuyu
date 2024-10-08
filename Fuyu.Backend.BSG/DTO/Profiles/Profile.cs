using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    // Assembly-CSharp.dll: EFT.Profile
    [DataContract]
    public class Profile
    {
        [DataMember]
        public MongoId _id;

        [DataMember]
        public int aid;

        [DataMember(EmitDefaultValue = false)]
        public MongoId savage;

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
        public Dictionary<MongoId, bool> Encyclopedia;

        [DataMember]
        public Dictionary<string, ConditionCounter> TaskConditionCounters;

        [DataMember]
        public InsuredItem[] InsuredItems;

        [DataMember]
        public HideoutInfo Hideout;

        [DataMember]
        public BonusInfo[] Bonuses;

        // TODO: proper type
        [DataMember]
        public object[] WishList;

        [DataMember]
        public NotesInfo Notes;

        [DataMember]
        public QuestInfo[] Quests;

        // TODO: proper type
        [DataMember]
        public Dictionary<MongoId, int> Achievements;

        [DataMember]
        public RagfairInfo RagfairInfo;

        [DataMember]
        public Dictionary<MongoId, TraderInfo> TradersInfo;

        [DataMember]
        public UnlockedInfo UnlockedInfo;

        [DataMember]
        public MoneyTransferLimitInfo moneyTransferLimitData;
    }
}