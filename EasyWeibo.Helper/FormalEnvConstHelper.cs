using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvHelper
{
	public class FormalEnvConstHelper : IEnvConstHelper
	{
		public string BaseUrl
		{
			get { return "http://gw.api.taobao.com/router/rest"; }
		}

		public string AuthorizeUrl
		{
			get { return string.Format("http://container.open.taobao.com/container?appkey={0}", AppKey); }
		}


		public string AppKey
		{
			get { return "21550668"; }
		}

		public string AppSecret
		{
			get { return "82c295060cbf228fb159c5af78bd3195"; }
		}
	}
}
