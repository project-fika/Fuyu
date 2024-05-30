using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Locations;

namespace Fuyu.Platform.Common.Models.EFT.Game.Spawning
{
    [DataContract]
    public struct ColliderParam
    {
        [DataMember]
        public string _parent;

        [DataMember]
        public ColliderProperties _props;
    }
}