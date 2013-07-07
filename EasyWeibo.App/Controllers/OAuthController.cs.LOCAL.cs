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
		public ViewResult GetAccessToken(string code, string state)
		{
			if (!string.IsNullOrEmpty(code))
			{
				if (this.obDic[state].Authorize(code))
				{
					ViewData["session"] = Tool.GetJosnValue(this.obDic[state].TokenResult, "access_token");					 
				}
			}
			return View();
		}
    }
}
