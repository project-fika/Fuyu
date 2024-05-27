using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Locations
{
    [DataContract]
    public struct MaxItemCount
    {
        [DataMember]
        public string TemplateId;

        [DataMember]
        public int Value;
    }
}