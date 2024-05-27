using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles.Hideout;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct HideoutInfo
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