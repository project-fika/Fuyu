using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct NotesInfo
    {
        [DataMember]
        public Note[] Notes;
    }
}