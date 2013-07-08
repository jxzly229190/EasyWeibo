using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWeibo.BLL.CustomException
{
	public class TokenVerificationException: Exception
	{
		public NetDimension.Weibo.TokenResult TokenResult { set; get; }
		public string Message { set; get; }
	}

	public class SendWeiboException : Exception
	{
		public string Message { set; get; }
	}
}
