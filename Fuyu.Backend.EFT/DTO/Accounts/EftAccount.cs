using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Accounts
{
    [DataContract]
    public class EftAccount
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string Edition;

        [DataMember]
        public string Username;

        [DataMember]
        public string PvpId;

        [DataMember]
        public string PveId;
    }
}