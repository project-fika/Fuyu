using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.MongoDB;

namespace Fuyu.Platform.Common.Models.EFT.Templates
{
    [DataContract]
    public struct MagazineBuildTemplate
    {
        [DataMember]
        public MongoID Id;
        
        [DataMember]
        public string Name;
        
        [DataMember]
        public string Caliber;
        
        [DataMember] 
        public int TopCount;
        
        [DataMember]
        public int BottomCount;
    }   
}