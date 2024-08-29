using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles;

namespace Fuyu.Platform.Common.Models.Fuyu.Savegame
{
    [DataContract]
    public struct EftProfile
    {
        [DataMember]
        public Profile Savage;

        [DataMember]
        public Profile Pmc;

        [DataMember]
        public string[] Suites;

        [DataMember]
        public bool ShouldWipe;
    }
}