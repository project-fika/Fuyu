using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
{
    [DataContract]
    public class AchievementStatisticResponse
    {
        [DataMember]
        public Dictionary<string, float> elements;
    }
}