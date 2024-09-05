using System.Runtime.Serialization;

namespace Fuyu.Server.EFT.DTO.Responses
{
    [DataContract]
    public class CustomizationStorageResponse
    {
        [DataMember]
        public string _id;

        [DataMember]
        public string[] suites;
    }
}