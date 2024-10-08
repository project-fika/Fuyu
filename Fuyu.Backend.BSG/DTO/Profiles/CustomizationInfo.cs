using System.Runtime.Serialization;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class CustomizationInfo
    {
        [DataMember]
        public MongoId Head;

        [DataMember]
        public MongoId Body;

        [DataMember]
        public MongoId Feet;

        [DataMember]
        public MongoId Hands;
    }
}