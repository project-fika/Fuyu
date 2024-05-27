using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Skills
{
    [DataContract]
    public struct Mastery
    {
        [DataMember] 
        public string Id;

        [DataMember]
        public int Progress;
    }
}