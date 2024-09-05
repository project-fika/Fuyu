using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class RagfairInfo
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