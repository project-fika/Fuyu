using System;
using Fuyu.Common.Collections;
using Newtonsoft.Json;

namespace Fuyu.Common.Serialization
{
	public class UnionConverter : JsonConverter
	{
		// NOTE: I don't think this gets ran at all but I'm leaving it
		// -- nexus4880, 2024-10-14
		public override bool CanConvert(Type objectType)
		{
			return objectType.IsAssignableFrom(typeof(IUnion));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			foreach (var type in objectType.GenericTypeArguments)
			{
				try
				{
					// NOTE: This will intentionally cause an exception because there
					// is no other way of seeing if a type can be deserialized
					// -- nexus4880, 2024-10-14
					var result = serializer.Deserialize(reader, type);

					// NOTE: This intentionally uses Activator.CreateInstance in order
					// to return a Union<T1, T2> from T1 or T2 directly
					// -- nexus4880, 2024-10-14
					return Activator.CreateInstance(objectType, result);
				}
				catch (JsonSerializationException)
				{
				}
			}

			throw new JsonSerializationException();
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, ((IUnion)value).Value);
		}
	}
}
