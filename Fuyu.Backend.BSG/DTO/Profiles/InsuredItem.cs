using System.Runtime.Serialization;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class InsuredItem
    {
        [DataMember]
        public MongoId tid;

        [DataMember]
        public MongoId itemId;
    }
}