using System.Runtime.Serialization;

namespace Fuyu.Server.BSG.DTO.Profiles
{
    [DataContract]
    public class NotesInfo
    {
        // TODO: proper type
        [DataMember]
        public object[] Notes;
    }
}