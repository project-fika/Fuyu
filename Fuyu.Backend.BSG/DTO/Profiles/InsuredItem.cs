using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Profiles
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