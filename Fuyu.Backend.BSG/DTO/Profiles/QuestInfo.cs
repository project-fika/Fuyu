using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles.Quests;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class QuestInfo
    {
        [DataMember]
        public MongoId qid;

        [DataMember]
        public long startTime;

        [DataMember]
        public EQuestStatus status;

        [DataMember]
        public Dictionary<string, long> statusTimers;
    }
}