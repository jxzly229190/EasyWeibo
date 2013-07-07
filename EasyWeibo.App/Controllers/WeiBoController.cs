using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetDimension.Weibo;

namespace EasyWeibo.App.Controllers
{
    public class WeiBoController : Controller
    {
        //
        // GET: /WeiBo/

		string access_key = string.Empty;
        public ActionResult Index(string session)
        {
			this.access_key = session;
			ViewData["session"] = session;
			return View();
        }

		public ActionResult SendWeibo(string content, string url, string session)
		{
			
			OAuth oau=new OAuth("997311183","cf684c318d5c314ae6358309c06dcf17",session,null);
			if (oau.VerifierAccessToken() == TokenResult.Success)
			{
				NetDimension.Weibo.Client client = new Client(oau);
				var result = client.API.Entity.Statuses.Update(content);
				if (result != null)
				{
					return View((object)"发送成功");
				}
			}
			return View((object)"发送失败");
		}

    }
}
