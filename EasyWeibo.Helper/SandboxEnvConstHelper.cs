﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvHelper
{
	public class SandboxEnvConstHelper : IEnvConstHelper
	{
		public string BaseUrl
		{
			get { return "http://gw.api.tbsandbox.com/router/rest"; }
		}

		public string AuthorizeUrl
		{
			get { return string.Format("http://container.api.tbsandbox.com/container?appkey={0}", AppKey); }
		}

		public string AppKey
		{
			get { return string.Empty; }
		}

		public string AppSecret
		{
			get { return string.Empty; }
		}
	}
}
