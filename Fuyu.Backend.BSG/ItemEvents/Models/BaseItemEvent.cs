using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.ItemEvents.Models
{
    [DataContract]
    public class BaseItemEvent
    {
        [DataMember(Name = "Action")]
        public string Action { get; }
    }
}
