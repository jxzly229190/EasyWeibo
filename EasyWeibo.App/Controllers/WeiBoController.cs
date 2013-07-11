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

		BLL.WeiboServiceBase ws = new BLL.SinaWeiboService();
        public ActionResult Index()
        {
			return View();
        }

		public ActionResult SendWeibo(string content, string url, string session)
		{
			if (ws.VerifyAccessToken() == TokenResult.Success)
			{
				ws.Send(new Model.WeiboMessage() { Content = content, Url=url });
				return View((object)"发送成功");
			}
			return View((object)"发送失败");
		}
    }
}
