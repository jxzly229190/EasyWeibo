using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyWeibo.App.Controllers
{
	public class HomeController : Controller
	{
        protected ActionResult Index()
        {
            if (Session["UID"] == null)
            {
                return this.View("RequestOauth");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Index(string code, string state)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return this.Index();
            }

            return this.RedirectToAction("GetAccessToken","OAuth");

        }
	}
}
