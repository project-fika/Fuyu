using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Profiles.Info
{
    [DataContract]
    public class Ban
    {
        [DataMember]
        public EBanType banType;

        [DataMember]
        public long dateTime;
    }
}