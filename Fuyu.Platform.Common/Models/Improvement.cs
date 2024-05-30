using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models
{
    
    [DataContract]
    public struct Improvement
    {
        [DataMember]
        public bool completed;
        
        [DataMember]
        public int improveCompleteTimestamp;
    }
}