using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Hideout;

namespace Fuyu.Platform.Common.Models.EFT.Profiles.Hideout
{
    [DataContract]
    public struct HideoutAreaSlot
    {
        // TODO: proper type
        [DataMember]
        public object item;
    }
}