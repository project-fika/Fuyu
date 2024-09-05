using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Profiles.Hideout
{
    [DataContract]
    public class HideoutAreaSlot
    {
        // TODO: proper type
        [DataMember]
        public object item;
    }
}