using System.Runtime.Serialization;
using Fuyu.Server.BSG.DTO.Profiles.Stats;

namespace Fuyu.Server.BSG.DTO.Profiles
{
    [DataContract]
    public class StatsInfo
    {
        [DataMember]
        public EftStats Eft;
    }
}