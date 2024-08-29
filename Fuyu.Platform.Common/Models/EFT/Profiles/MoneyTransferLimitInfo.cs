using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct MoneyTransferLimitInfo
    {
        [DataMember]
        public int items;

        [DataMember]
        public int nextResetTime;
        
        [DataMember]
        public int remainingLimit;
        
        [DataMember]
        public int totalLimit;
        
        [DataMember]
        public int resetInterval;
    }
}