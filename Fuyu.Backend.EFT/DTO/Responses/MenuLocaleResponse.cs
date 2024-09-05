using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Responses
{
    [DataContract]
    public class MenuLocaleResponse
    {
        [DataMember]
        public Dictionary<string, string> menu;
    }
}