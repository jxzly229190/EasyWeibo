using System;
using EasyWeibo.Helper;
using EasyWeibo.BLL;

namespace EasyWeibo.BLL
{
	public class TaoBaoOAuth2 : OAuth2Base
	{
		private readonly bool _isUseSandBox = false;
		public bool IsUseSandBox
		{
			get
			{
				return _isUseSandBox;
			}
		}
		public override Mappings.PlatForm Server
		{
			get
			{
				return Mappings.PlatForm.TaoBao;
			}
		}
		public override string ImgUrl
		{
			get
			{
				return "<img align='absmiddle' src=\"/skin/system_tech/images/oauth_taobao.png\" /> 淘宝";
			}
		}
		public override string OAuthUrl
		{
			get
			{
				if (!IsUseSandBox)
					return string.Format("https://oauth.taobao.com/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}", this.AppKey, this.CallbackUrl, this.Server);
				else
					return string.Format("https://oauth.tbsandbox.com/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}", this.AppKey, this.CallbackUrl, this.Server);
			}
		}
		public override string TokenUrl
		{
			get
			{
				if (!IsUseSandBox)
					return "https://oauth.taobao.com/token";
				else
					return "https://oauth.tbsandbox.com/token";
			}
		}

		public override string PlatformUId
		{
			get { return Helper.StringParserHelper.GetJosnValue(TokenResultJson, "taobao_user_id"); }
		}

		public override string AccessToken
		{
			get { return Helper.StringParserHelper.GetJosnValue(this.TokenResultJson, "access_token"); }
		}

		public override string AppKey
		{
			get
			{
				if (!IsUseSandBox)
					return base.AppKey;
				else
					return StringParserHelper.GetConfig(Server.ToString() + ".SandBoxAppKey");
			}
		}

		public override string AppSecret
		{
			get 
			{
				return IsUseSandBox ? StringParserHelper.GetConfig(Server.ToString() + ".SandBoxAppSercet") : base.AppSecret;
			}
		}

		public override string BaseUrl
		{
			get
			{
				if (!IsUseSandBox)
					return base.BaseUrl;
				else
					return StringParserHelper.GetConfig(Server.ToString() + ".SandBoxBaseUrl");
			}
		}

		public TaoBaoOAuth2()
		{
			_isUseSandBox = bool.Parse(StringParserHelper.GetConfig("UseTaoBaoSandBox"));
		}

		public override string RefreshToken
		{
			get { return Helper.StringParserHelper.GetJosnValue(this.TokenResultJson, "refresh_token"); }
		}
	}
}
