using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Items
{
    [DataContract]
    public struct ItemFireMode
    {
        [DataMember]
        public string FireMode;
    }
}