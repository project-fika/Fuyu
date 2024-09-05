using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles.Hideout;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class HideoutInfo
    {
        // TODO: proper type
        [DataMember]
        public object Production;

        [DataMember]
        public HideoutAreaInfo[] Areas;

        // TODO: proper type
        [DataMember]
        public object Improvements;

        [DataMember]
        public long Seed;
    }
}