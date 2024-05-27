using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
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