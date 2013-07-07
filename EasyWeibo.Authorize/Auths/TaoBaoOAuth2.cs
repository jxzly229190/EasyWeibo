using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWeibo.Authorize
{
	public class TaoBaoOAuth2 : OAuth2Base
	{
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
				return string.Format("https://oauth.taobao.com/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}", this.AppKey, this.CallbackUrl, this.server);
			}
		}
		public override string TokenUrl
		{
			get
			{
				return "https://oauth.taobao.com/token";
			}
		}

		public override string AppKey
		{
			get
			{
				if (!Boolean.Parse(Tool.GetConfig("UseTaoBaoSandBox")))
					return base.AppKey;
				else
					return Tool.GetConfig(server.ToString() + ".SandBoxAppKey");
			}
		}

		public override string AppSercet
		{
			get
			{
				if (!Boolean.Parse(Tool.GetConfig("UseTaoBaoSandBox")))
					return base.AppSercet;
				else
					return Tool.GetConfig(server.ToString() + ".SandBoxAppSercet");
			}
		}
	}
}
