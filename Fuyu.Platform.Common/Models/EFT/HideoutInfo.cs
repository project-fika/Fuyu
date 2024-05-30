using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Hideout;
using Fuyu.Platform.Common.Models.EFT.Profiles;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct HideoutInfo
    {
        [DataMember]
        public Dictionary<string, ProductionData> Production;

        [DataMember]
        public HideoutAreaInfo[] Areas;

        [DataMember]
        public Dictionary<string, Improvement> Improvements;

        [DataMember]
        public long Seed;
    }
}