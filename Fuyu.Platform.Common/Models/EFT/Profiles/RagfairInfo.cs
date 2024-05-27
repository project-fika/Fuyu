using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct RagfairInfo
    {
        [DataMember]
        public float rating;

        [DataMember]
        public bool isRatingGrowing;

        // TODO: proper type
        [DataMember]
        public object[] offers;
    }
}