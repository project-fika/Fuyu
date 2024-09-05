using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Server.BSG.DTO.Profiles.Quests;

namespace Fuyu.Server.BSG.DTO.Profiles
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