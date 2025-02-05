using Library.Domain.Abstracts;
using Newtonsoft.Json;

namespace Library.WebUI.Extensions;

public static class SessionExtensionsMethod
{
    public static void SetObject(this ISession session, string key, object value)
    {
        string objectString = JsonConvert.SerializeObject(value);
        session.SetString(key, objectString);
    }

    public static T GetObject<T>(this ISession session, string key)
    {
        string objectString = session.GetString(key);
        if (string.IsNullOrEmpty(objectString))
            return default;

        return JsonConvert.DeserializeObject<T>(objectString, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        });
    }
}
