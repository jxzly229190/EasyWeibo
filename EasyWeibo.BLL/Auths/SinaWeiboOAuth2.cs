using EasyWeibo.Helper;

namespace EasyWeibo.BLL
{
	public class SinaWeiboOAuth2:OAuth2Base
	{
		public override string PlatformUId
		{
			get { return Helper.StringParserHelper.GetJosnValue(TokenResultJson, "uid"); }
		}

		public override string AccessToken
		{
			get
			{
				return Helper.StringParserHelper.GetJosnValue(this.TokenResultJson, "access_token");
			}
		}

		public override string RefreshToken
		{
			//新浪微博暂时没有提供RefreshToken。
			get { throw new System.NotImplementedException(); }
		}

		public override Mappings.PlatForm Server
		{
			get
			{
				return Mappings.PlatForm.SinaWeiBo;
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
				return string.Format("https://api.weibo.com/oauth2/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}", this.AppKey, this.CallbackUrl, this.Server);
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

		public override System.DateTime ExpireTime
		{
			get { throw new System.NotImplementedException(); }
		}
	}
}
