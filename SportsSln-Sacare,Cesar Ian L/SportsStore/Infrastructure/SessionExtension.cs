using System.Text.Json;
namespace SportsStore.Infrastructure
{
	public static class SessionExtension
	{
		public static void setJson(this ISession session, string key, object value)
		{
			session.SetString(key, JsonSerializer.Serialize(value));
		}

		public static T? Getjson<T>(this ISession session, string key)
		{
			var SessionData = session.GetString(key);
			return SessionData == null
				? default(T) : JsonSerializer.Deserialize<T>(SessionData);
		}
	}
}
