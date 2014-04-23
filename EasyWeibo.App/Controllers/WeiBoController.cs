using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetDimension.Weibo;

namespace EasyWeibo.App.Controllers
{
    using EasyWeibo.BLL;

    public class WeiBoController : Controller
    {
        //
        // GET: /WeiBo/

		string access_key = string.Empty;

		BLL.WeiboServiceBase ws;
        public ActionResult Index()
        {
			return View();
        }

		public ActionResult SendWeibo(string content, string url, string session)
		{
		    var weiboSessionKeyObj = Session[Helper.PlatformSessionKeyHelper.SinaWeiboSessionKeyName];
		    string weiboSessionKey = null;
		    if (weiboSessionKeyObj == null)
		    {
		        if (Session["UID"] == null)
		        {
		            return this.Content("用户为空");
		        }
		        var weiboPF = new OAuthService().GetPlatforminfoByUserID(int.Parse(Session["UID"].ToString()));

                if (weiboPF == null)
                {
                    return this.Content("用户平台信息为空");
                }

		        weiboSessionKey = weiboPF.SessionKey;

		        var result = new SinaWeiboService(weiboSessionKey).VerifyAccessToken();

		        if (result != TokenResult.Success)
		        {
		            return this.Content("授权无效或已过期，请重新授权。");
		        }
		    }

		    ws = new SinaWeiboService(weiboSessionKey);
			if (ws.VerifyAccessToken() == TokenResult.Success)
			{
			    ws.Send(new Model.WeiboMessage() { Content = content, Url = url });
				return View((object)"发送成功");
			}
			return View((object)"发送失败");
		}
    }
}
