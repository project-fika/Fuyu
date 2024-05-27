using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct AchievementStatisticResponse
    {
        [DataMember]
        public Dictionary<string, float> elements;
    }
}