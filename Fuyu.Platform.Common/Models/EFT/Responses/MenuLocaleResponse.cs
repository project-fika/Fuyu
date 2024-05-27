using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct MenuLocaleResponse
    {
        [DataMember]
        public Dictionary<string, string> menu;
    }
}