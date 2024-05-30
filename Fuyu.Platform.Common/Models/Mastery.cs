using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct Mastery
    {
        [DataMember] 
        public string Id;

        [DataMember]
        public int Progress;
    }
}