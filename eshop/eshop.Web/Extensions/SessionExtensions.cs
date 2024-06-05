using Newtonsoft.Json;

namespace eshop.Web.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            var serialized = JsonConvert.SerializeObject(value);
            session.SetString(key, serialized);
        }

        public static T? GetJson<T>(this ISession session, string key) where T : class
        {
            var serialized = session.GetString(key);
            return string.IsNullOrEmpty(serialized) ? null : JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
