using System.Runtime.Serialization;
using Fuyu.Server.BSG.DTO.Profiles;

namespace Fuyu.Server.EFT.DTO.Accounts
{
    [DataContract]
    public class EftProfile
    {
        [DataMember]
        public Profile Pmc;

        [DataMember]
        public Profile Savage;

        [DataMember]
        public string[] Suites;

        [DataMember]
        public bool ShouldWipe;
    }
}