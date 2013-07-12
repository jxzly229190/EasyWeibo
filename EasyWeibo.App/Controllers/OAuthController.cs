using System.Collections.Generic;
using System.Web.Mvc;
using EasyWeibo.BLL;
using EasyWeibo.Helper;
using Top.Api.Domain;

namespace EasyWeibo.App.Controllers
{
	public class OAuthController : Controller
	{
		private IDictionary<string, OAuth2Base> obDic = OAuth2Factory.ServerList;
		private TaobaoService tbService;
		public OAuthController()
		{
			tbService = new TaobaoService();
		}
		//
		// GET: /OAuth/

		//OAuth2Base ob = OAuth2Factory.TaoBaoAuther;
		
		public ActionResult Index()
		{
			return View(obDic);
		}

		[HttpGet]
		public ViewResult GetAccessToken(string code, string state)
		{
			if (!string.IsNullOrEmpty(code))
			{			
				string sessionKey = string.Empty;
				if (obDic[state].server == EasyWeibo.Helper.Mappings.PlatForm.TaoBao && bool.Parse(StringParserHelper.GetConfig("UseTaoBaoSandBox")))
				{
					sessionKey = "6101925c77e6ac6b8ddaa3606de6fd7d21401fc18e51eb43598702902";
				}
				else
				{
					BLL.OAuthService authService = new BLL.OAuthService();
					authService.RegisterPlatformSession(obDic[state], code);
					sessionKey = obDic[state].AccessToken;
					switch (obDic[state].server)
					{
						case EasyWeibo.Helper.Mappings.PlatForm.SinaWeiBo:
							Session[Helper.PlatformSessionKeyHelper.SinaWeiboSessionKeyName] = sessionKey;
							break;
						case EasyWeibo.Helper.Mappings.PlatForm.TaoBao:
							Session[Helper.PlatformSessionKeyHelper.TaobaoSessionKeyName] = sessionKey;
							break;
						case EasyWeibo.Helper.Mappings.PlatForm.QQWeiBo:
							Session[Helper.PlatformSessionKeyHelper.QQSessionKeyName] = sessionKey;
							break;
						default:
							break;
					}
				}
				ViewData["session"] = sessionKey;
				User user = tbService.GetSellerUserInfo(sessionKey);
				Session["Nick"] = user.Nick;
			}

			return View();
		}
	}
}
