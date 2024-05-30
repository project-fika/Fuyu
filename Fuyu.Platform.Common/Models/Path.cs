using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct Path
    {
        [DataMember]
        public string Source;

        [DataMember]
        public string Destination;
    }
}