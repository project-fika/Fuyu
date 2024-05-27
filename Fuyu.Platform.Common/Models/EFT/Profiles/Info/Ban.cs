using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Info
{
    [DataContract]
    public struct Ban
    {
        [DataMember]
        public EBanType banType;

        [DataMember]
        public long dateTime;
    }
}