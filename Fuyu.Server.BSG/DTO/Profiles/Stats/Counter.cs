using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Profiles.Stats
{
    [DataContract]
    public class Counter
    {
        // TODO: proper type
        [DataMember]
        public object[] Items;
    }
}