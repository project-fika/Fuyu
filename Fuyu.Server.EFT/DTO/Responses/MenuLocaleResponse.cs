using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Responses
{
    [DataContract]
    public class MenuLocaleResponse
    {
        [DataMember]
        public Dictionary<string, string> menu;
    }
}