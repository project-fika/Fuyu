using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles.Quests;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class QuestInfo
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