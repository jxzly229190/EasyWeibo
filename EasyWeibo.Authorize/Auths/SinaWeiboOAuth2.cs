using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWeibo.Authorize
{
	public class SinaWeiboOAuth2:OAuth2Base
	{
		public override string AccessToken
		{
			get
			{
				return Helper.StringParserHelper.GetJosnValue(this.TokenResultJosn, "access_token");
			}
		}

		public override OAuthServer server
		{
			get
			{
				return OAuthServer.SinaWeiBo;
			}
		}
		public override string ImgUrl
		{
			get
			{
				return "<img align='absmiddle' src=\"/skin/system_tech/images/oauth_sinaweibo.png\" /> 微博";
			}
		}
		public override string OAuthUrl
		{
			get
			{
				return string.Format("https://api.weibo.com/oauth2/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}", this.AppKey, this.CallbackUrl, this.server);
			}
		}
		public override string TokenUrl
		{
			get
			{
				return "https://api.weibo.com/oauth2/access_token";
			}
		}
		public string UserInfoUrl = "https://api.weibo.com/2/users/show.json?access_token={0}&uid={1}";
	}
}
