using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.ItemEvents.Models
{
    [DataContract]
    public class InventoryWarning
    {
        [DataMember(Name = "index")]
        public int RequestIndex { get; set; }

        [DataMember(Name = "errmsg")]
        public string ErrorMessage { get; set; }

        [DataMember(Name = "code")]
        public string ErrorCode { get; set; }

		[DataMember(Name = "data")]
		public object Data;
	}
}
