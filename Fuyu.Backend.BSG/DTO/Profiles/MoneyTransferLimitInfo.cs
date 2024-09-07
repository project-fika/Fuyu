using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class MoneyTransferLimitInfo
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