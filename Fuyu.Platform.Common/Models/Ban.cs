using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT;

namespace Fuyu.Platform.Common.Models
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