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

		OAuth2Base ob = OAuth2Factory.TaoBaoAuther;
        public ActionResult Index()
        {
			return View(ob);
        }

		[HttpGet]
		public string GetAccessToken(string code, string state)
		{
			if (!string.IsNullOrEmpty(code))
			{
				if (this.ob.Authorize(code))
				{
					return ob.TokenResult;
				}
			}

			return "授权失败";
		}
    }
}
