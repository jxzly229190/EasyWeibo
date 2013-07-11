using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyWeibo.Helper;

namespace EasyWeibo.Authorize
{
	public class TaoBaoOAuth2 : OAuth2Base
	{
		private bool _isUseSandBox = false;
		public bool IsUseSandBox
		{
			get
			{
				return _isUseSandBox;
			}
		}
		public override OAuthServer server
		{
			get
			{
				return OAuthServer.TaoBao;
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
					return string.Format("https://oauth.taobao.com/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}", this.AppKey, this.CallbackUrl, this.server);
				else
					return string.Format("https://oauth.tbsandbox.com/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}", this.AppKey, this.CallbackUrl, this.server);
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

		public override string AppKey
		{
			get
			{
				if (!IsUseSandBox)
					return base.AppKey;
				else
					return StringParserHelper.GetConfig(server.ToString() + ".SandBoxAppKey");
			}
		}

		public override string AppSercet
		{
			get
			{
				if (!IsUseSandBox)
					return base.AppSercet;
				else
					return StringParserHelper.GetConfig(server.ToString() + ".SandBoxAppSercet");
			}
		}

		public TaoBaoOAuth2()
		{
			_isUseSandBox = bool.Parse(StringParserHelper.GetConfig("UseTaoBaoSandBox"));
		}
	}
}
