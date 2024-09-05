using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Responses
{
    [DataContract]
    public class AchievementStatisticResponse
    {
        [DataMember]
        public Dictionary<string, float> elements;
    }
}