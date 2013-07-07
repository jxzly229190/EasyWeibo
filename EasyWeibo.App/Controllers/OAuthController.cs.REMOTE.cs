using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyWeibo.Authorize;

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
		public string GetAccessToken(string code, string state)
		{
			if (!string.IsNullOrEmpty(code))
			{
				if (this.obDic[state].Authorize(code))
				{
					return obDic[state].TokenResult;
				}
			}

			return "授权失败";
		}
    }
}
