// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using Unity.Plastic.Newtonsoft.Json;

namespace RCFramework.Tools
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}