using System;
using Newtonsoft.Json;

namespace MediaListingApp.Core.Helpers
{
public static class Extentions
{
	public static string ToJsonString(this object obj)
	{
		if (obj == null) return string.Empty;
		try
		{
			var result = JsonConvert.SerializeObject(obj);
			return result;
		}
		catch (Exception ex)
		{
			return string.Empty;
		}
	}

	public static T ToObject<T>(this string json)
		where T : class
	{
		if (string.IsNullOrWhiteSpace(json)) return default(T);
		try
		{
			var result = JsonConvert.DeserializeObject<T>(json);
			return result;
		}
		catch (Exception ex)
		{
			return default(T);
		}
	}
}
}
