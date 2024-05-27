using System.Runtime.Serialization;

namespace Fuyu.Platform.Common.Models.EFT.Responses
{
    [DataContract]
    public struct CustomizationStorageResponse
    {
        [DataMember]
        public string _id;

        [DataMember]
        public string[] suites;
    }
}