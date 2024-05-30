using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Common;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct BodyPart
    {
        [DataMember]
        public CurrentMaximum<float> Health;

        [DataMember]
        public Dictionary<string, EffectTimer> Effects;
    } 
}