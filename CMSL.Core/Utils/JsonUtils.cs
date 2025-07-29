using System.Text.Json;

namespace CMSL.Core.Utils;

public static class JsonUtils
{
    public static T? Parse<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }

    public static T? Parse<T>(Stream? stream)
    {
        if (stream == null)
        {
            return default;
        }
        
        return JsonSerializer.Deserialize<T>(stream);
    }
    
    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj);
    }
    
    public static void Serialize<T>(T obj, Stream stream)
    {
        JsonSerializer.Serialize(stream, obj);
    }
}