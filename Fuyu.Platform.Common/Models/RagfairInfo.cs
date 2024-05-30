using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.UI.Ragfair;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct RagfairInfo
    {
        [DataMember]
        public float rating;

        [DataMember]
        public bool isRatingGrowing;

        [DataMember]
        public Offer[] offers;
    }
}