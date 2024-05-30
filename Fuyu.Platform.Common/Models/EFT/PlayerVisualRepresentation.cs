using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Profiles;

namespace Fuyu.Platform.Common.Models.EFT
{
    [DataContract]
    public struct PlayerVisualRepresentation
    {
        [DataMember]
        public PlayerVisualRepresentationInfo Info;
        [DataMember]
        private Dictionary<EBodyModelPart, String> Customization;
    }
}