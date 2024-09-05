using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Profiles
{
    [DataContract]
    public class InsuredItem
    {
        [DataMember]
        public string tid;

        [DataMember]
        public string itemId;
    }
}