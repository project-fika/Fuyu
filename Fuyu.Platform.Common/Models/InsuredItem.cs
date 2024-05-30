using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct InsuredItem
    {
        [DataMember]
        public string tid;

        [DataMember]
        public string itemId;
    }
}