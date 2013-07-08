using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EasyWeibo.BLL.Helper
{
	public static class ContextHelper
	{
		public static System.Web.SessionState.HttpSessionState CurrentSession
		{
			get { return HttpContext.Current.Session; }
		}
	}
}
