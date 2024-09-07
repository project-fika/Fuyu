using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fuyu.Backend.Arena.DTO.Responses
{
    [DataContract]
    public class MenuLocaleResponse
    {
        [DataMember]
        public Dictionary<string, string> menu;
    }
}