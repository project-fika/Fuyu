using System;
using System.Runtime.Serialization;

namespace Fuyu.Backend.EFT.DTO.Items
{
	[DataContract]
    public class LocationInGrid : IEquatable<LocationInGrid>
    {
        [DataMember]
        public int x;

        [DataMember]
        public int y;

        [DataMember]
        public EItemRotation r;

        // emits when 'false'
        [DataMember(EmitDefaultValue = false)]
        public bool isSearched;

		public bool Equals(LocationInGrid other)
		{
            return other.x == x && other.y == y && other.r == r;
		}
	}
}