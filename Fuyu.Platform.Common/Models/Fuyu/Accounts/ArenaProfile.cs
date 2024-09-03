using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles;

namespace Fuyu.Platform.Common.Models.Fuyu.Accounts
{
    [DataContract]
    public struct ArenaProfile
    {
        [DataMember]
        public Profile Pmc;

        [DataMember]
        public string[] Suites;

        [DataMember]
        public bool ShouldWipe;
    }
}