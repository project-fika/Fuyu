using Newtonsoft.Json;

namespace Fuyu.Platform.Common.Serialization
{
    public static class Json
    {
        public static T Parse<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string Stringify(object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}