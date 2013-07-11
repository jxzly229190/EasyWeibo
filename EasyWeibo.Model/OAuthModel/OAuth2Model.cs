using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWeibo.Model
{
	class OAuth2Model
	{		
		public string UID { set; get; }
		public string AppKey { set; get; }
		public string AppSecret { set; get; }
		public string AccessToken { set; get; }
		public DateTime AuthDate { set; get; }
	}
}
