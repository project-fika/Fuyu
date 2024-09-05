using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles.Stats;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class StatsInfo
    {
        [DataMember]
        public EftStats Eft;
    }
}