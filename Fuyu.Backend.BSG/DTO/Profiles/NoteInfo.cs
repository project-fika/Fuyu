using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Profiles
{
    [DataContract]
    public class NotesInfo
    {
        // TODO: proper type
        [DataMember]
        public object[] Notes;
    }
}