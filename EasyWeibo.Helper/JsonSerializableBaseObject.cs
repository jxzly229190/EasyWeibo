using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWeibo.Helper
{
	public class JsonSerializableBaseObject<T> where T : class
	{
		public string Serialize()
		{
			return JsonObjectSerializerHelper.Serialize(typeof(T), this);
		}

		public static T Deserialize(string content)
		{
			return JsonObjectSerializerHelper.Deserialize(typeof(T), content) as T;
		}
	}
}
