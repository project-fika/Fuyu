using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
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