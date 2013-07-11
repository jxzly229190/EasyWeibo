using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyWeibo.Authorize;
using EasyWeibo.Helper;

namespace EasyWeibo.App.Controllers
{
    public class OAuthController : Controller
    {
        //
        // GET: /OAuth/

		//OAuth2Base ob = OAuth2Factory.TaoBaoAuther;
		IDictionary<string, OAuth2Base> obDic = OAuth2Factory.ServerList;
        public ActionResult Index()
        {
			return View(obDic);
        }

		[HttpGet]
		public ViewResult GetAccessToken(string code, string state)
		{
			if (!string.IsNullOrEmpty(code))
			{
				BLL.OAuthService authService = new BLL.OAuthService();
				authService.RegisterPlatformSession(obDic[state], code);				
			}
			return View();
		}
    }
}
