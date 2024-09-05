using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Responses
{
    [DataContract]
    public class ResponseBody<T>
    {
        [DataMember]
        public int err;

        // emits when 'null'
        [DataMember(EmitDefaultValue = false)]
        public string errmsg;

        // emits when 'default(T)'
        [DataMember(EmitDefaultValue = false)]
        public T data;

        // emits when '0'
        [DataMember(EmitDefaultValue = false)]
        public int crc;
    }
}