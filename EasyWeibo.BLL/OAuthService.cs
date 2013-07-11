using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyWeibo.Authorize;
using Top.Api.Domain;

namespace EasyWeibo.BLL
{
	public class OAuthService
	{
		public void RegisterPlatformSession(OAuth2Base oa,string code)
		{
			if(!string.IsNullOrEmpty(code)&&oa!=null)
			{
			    if(oa.Authorize(code))
			    {
					switch (oa.server)
					{
						case OAuthServer.SinaWeiBo:
							Helper.ContextHelper.CurrentSession[Helper.PlatformSessionKeyHelper.SinaWeiboSessionKeyName] = oa.AccessToken;
							break;
						default:
							Helper.ContextHelper.CurrentSession[Helper.PlatformSessionKeyHelper.TaobaoSessionKeyName] = oa.AccessToken;
							break;
					}
			    }
			}
		}




	}

}
