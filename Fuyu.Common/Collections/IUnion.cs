using Fuyu.Common.Serialization;
using Newtonsoft.Json;

namespace Fuyu.Common.Collections
{
	// NOTE: This type exists so that any Union can be
	// deserialized using the UnionConverter. This is
	// because one may want to add a Union<T1, T2, T3>
	// or even more types later, which this SHOULD
	// support in theory, I have not tested it nor will I
	// -- nexus, 2024-10-22

	[JsonConverter(typeof(UnionConverter))]
	public interface IUnion
	{
		object Value { get; }
	}
}
