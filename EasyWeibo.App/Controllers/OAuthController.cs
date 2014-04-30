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
		//start SandBox URL: http://127.0.0.1:1472/OAuth/GetAccessToken?code=jDEeshF0i0SPPJKI1CoGoFD12051&state=TaoBao
		private readonly IDictionary<string, OAuth2Base> obDic = OAuth2Factory.ServerList;
		public OAuthController()
		{
		}
		//
		// GET: /OAuth/

		//OAuth2Base ob = OAuth2Factory.TaoBaoAuther;

	    public ActionResult Index()
	    {
	        return this.View(obDic);
	    }

		[HttpGet]
		public ViewResult GetAccessToken(string code, string state)
		{
			var authService = new BLL.OAuthService();
			string sessionKey = string.Empty;

			OAuth2Model authinfo;
		    long userId;
		    platforminfo platformInfo;
		    switch (obDic[state].Server)
			{
				case Mappings.PlatForm.TaoBao:

					var info = authService.RegisterTaoBaoSession(obDic[state], code);
					sessionKey = info.AccessToken;
					Session["UID"] = info.UserId;
					Session["Nick"] = info.Nick;

					Session[Helper.PlatformSessionKeyHelper.TaobaoSessionKeyName] = sessionKey;
					break;
				case Mappings.PlatForm.SinaWeiBo:
					userId = (long) this.Session["UID"];
					platformInfo = authService.RegisterPlatformSession(this.obDic[state], code, userId);
					Session[Helper.PlatformSessionKeyHelper.SinaWeiboSessionKeyName] = platformInfo.SessionKey;
                    //从数据库取
					break;
                case Mappings.PlatForm.QQ:
                    userId = (long)this.Session["UID"];
                    platformInfo = authService.RegisterPlatformSession(this.obDic[state], code, userId);
                    Session[Helper.PlatformSessionKeyHelper.QQSessionKeyName] = platformInfo.SessionKey;
			        Session[Helper.PlatformSessionKeyHelper.QQOpenID] = (this.obDic[state] as QQWeiboOAuth2).OpenID;
                    //从数据库取
                    break;
				default:
					break;
			}

		    return View();
		}
	}
}
