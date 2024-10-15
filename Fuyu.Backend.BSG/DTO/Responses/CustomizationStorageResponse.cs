using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.DTO.Responses
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