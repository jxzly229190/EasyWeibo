using System.Collections.Generic;
using System.Web.Mvc;
using EasyWeibo.BLL;
using EasyWeibo.Helper;
using Top.Api.Domain;
using EasyWeibo.Model;
using System;

namespace EasyWeibo.App.Controllers
{
	public class OAuthController : Controller
	{
		private readonly IDictionary<string, OAuth2Base> obDic = OAuth2Factory.ServerList;
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
			BLL.OAuthService authService = new BLL.OAuthService();
			string sessionKey = null;
			if (obDic[state].Server == Mappings.PlatForm.TaoBao)
			{
				if ((obDic[state] as TaoBaoOAuth2).IsUseSandBox)
				{
					sessionKey = "6101925c77e6ac6b8ddaa3606de6fd7d21401fc18e51eb43598702902";
				}
				else
				{
					authService.RegisterPlatformSession(obDic[state], code);
					sessionKey = obDic[state].AccessToken;
				}

				userinfo info = tbService.GetUserInfoBySessionKey(sessionKey);
				if (info == null)
				{
					info = new userinfo();
					User user = tbService.GetSellerUserInfo(sessionKey);
					info.Nick = user.Nick;
					info.TB_UserId = user.UserId.ToString();
					info.AccessToken = sessionKey;
					info.AuthDate = DateTime.Now;
					info.RefreshToken = string.Empty;
					info.LastLogin = DateTime.Now;
					tbService.SaveUserInfo(info);
				}
				Session["SessionKey"] = sessionKey;
				Session["Nick"] = info.Nick;
				return View();
			}

			authService.RegisterPlatformSession(obDic[state], code);
			sessionKey = obDic[state].AccessToken;

			switch (obDic[state].Server)
			{
				case Mappings.PlatForm.SinaWeiBo:
					Session[Helper.PlatformSessionKeyHelper.SinaWeiboSessionKeyName] = sessionKey;
					break;
				case Mappings.PlatForm.QQWeiBo:
					Session[Helper.PlatformSessionKeyHelper.QQSessionKeyName] = sessionKey;
					break;
				default:
					break;
			}

			Session["SessionKey"] = sessionKey;
			return View();
		}
	}
}
