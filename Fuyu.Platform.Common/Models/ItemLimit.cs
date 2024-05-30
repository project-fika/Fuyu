using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct ItemLimit
    {
        [DataMember]
        public string[] items;

        [DataMember]
        public int min;

        [DataMember]
        public int max;
    }
}