using System;
using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models
{
    [DataContract]
    public struct Note
    {
        [NonSerialized]
        public const int TextCharacterLimit = 1024;

        [NonSerialized]
        public const int NotesLimit = 50;

        [DataMember]
        public float Time;

        [DataMember]
        public string Text;
    }
}