using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles.Quests;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct QuestInfo
    {
        [DataMember]
        public string qid;

        [DataMember]
        public long startTime;

        [DataMember]
        public EQuestStatus status;

        [DataMember]
        public Dictionary<string, long> statusTimers;
    }
}