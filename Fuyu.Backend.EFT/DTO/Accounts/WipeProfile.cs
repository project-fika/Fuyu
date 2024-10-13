using System.Runtime.Serialization;
using Fuyu.Backend.BSG.DTO.Profiles;

namespace Fuyu.Backend.EFT.DTO.Accounts
{
    [DataContract]
    public class WipeProfile
    {
        [DataMember]
        public Profile Profile;

        [DataMember]
        public string[] Suites;
    }
}