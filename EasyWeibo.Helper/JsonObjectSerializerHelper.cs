using System;
using Newtonsoft.Json;

namespace EasyWeibo.Helper
{
	public class JsonObjectSerializerHelper
	{
		public static string Serialize(Type t, object obj)
		{
			return JsonConvert.SerializeObject(obj, t, Formatting.None, null);
		}

		public static object Deserialize(Type t, string content)
		{
			object result = null;
			result = JsonConvert.DeserializeObject(content, t);
			return result;
		}
	}
}
