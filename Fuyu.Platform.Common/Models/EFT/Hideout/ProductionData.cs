using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Items;

namespace Fuyu.Platform.Common.Models.EFT.Hideout
{
    [DataContract]
    public struct ProductionData
    {
        [DataMember]
        public float Progress;

        [DataMember]
        public int StartTimestamp;

        [DataMember]
        public int ProductionTime;

        [DataMember]
        public bool inProgress;

        [DataMember]
        public string RecipeId;

        [DataMember]
        public ItemInstance[] Products;

        [DataMember]
        public bool Interrupted;
    }
}