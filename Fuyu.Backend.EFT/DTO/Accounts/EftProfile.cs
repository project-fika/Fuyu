using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles;

namespace Fuyu.Backend.EFT.DTO.Accounts
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