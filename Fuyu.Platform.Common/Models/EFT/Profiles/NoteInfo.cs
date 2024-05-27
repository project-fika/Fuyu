using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Profiles
{
    [DataContract]
    public struct NotesInfo
    {
        // TODO: proper type
        [DataMember]
        public object[] Notes;
    }
}