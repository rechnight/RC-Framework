// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using Unity.Plastic.Newtonsoft.Json;

namespace RCFramework.Tools
{
    public class JsonSerializer : ISerializer
    {
        string ISerializer.Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        T ISerializer.Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
