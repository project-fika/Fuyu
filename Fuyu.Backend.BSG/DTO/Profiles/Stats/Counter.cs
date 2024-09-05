using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Profiles.Stats
{
    [DataContract]
    public class Counter
    {
        // TODO: proper type
        [DataMember]
        public object[] Items;
    }
}