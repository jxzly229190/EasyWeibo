using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetDimension.Weibo;

namespace EasyWeibo.App.Controllers
{
    using EasyWeibo.BLL;
    using EasyWeibo.Helper;
    using EasyWeibo.Model;

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

		public ActionResult SendWeibo(string content, string url, string[] platform)
		{
		    try
		    {
		        if (platform.Contains("S"))
		        {
		            this.SendSinaWeibo(content, url);
		        }

		        if (platform.Contains("Q"))
		        {
		            this.SendQQWeibo(content, url);
		        }

		        return this.View();
		    }
		    catch (Exception exception)
		    {
		        ViewBag.ErrorMessage = exception.Message;
                return this.View("ShowError");
		    }
		}

        private void SendQQWeibo(string content, string url)
        {
            string openId = "";
            var weiboSessionKeyObj = Session[Helper.PlatformSessionKeyHelper.QQSessionKeyName];
            string weiboSessionKey = null;
            if (weiboSessionKeyObj == null)
            {
                if (Session["UID"] == null)
                {
                    throw new Exception("用户名为空");
                }

                int uid = int.Parse(Session["UID"].ToString());
                var pName = Mappings.PlatForm.QQWeiBo.ToString("G");
                var weiboPF = new OAuthService().QueryPlatforminfo(p => p.UserId == uid && p.Platform == pName);

                if (weiboPF == null)
                {
                    throw new Exception("用户平台信息为空");
                }

                if (weiboPF.ExpireDate <= DateTime.Now)
                {
                    throw new Exception("授权无效或已过期，请重新授权。");
                }

                weiboSessionKey = weiboPF.SessionKey;
                openId = weiboPF.OpenId;
            }
            else
            {
                weiboSessionKey = weiboSessionKeyObj.ToString();
                openId = Session[PlatformSessionKeyHelper.QQOpenID].ToString();
            }

            ws = new QQWeiboService(
                StringParserHelper.GetConfig(Mappings.PlatForm.QQ.ToString("G") + ".AppKey"),
                StringParserHelper.GetConfig(Mappings.PlatForm.QQ.ToString("G") + ".AppSercet"),
                weiboSessionKey,
                openId);

            ws.Send(new Model.WeiboMessage { Content = content, Url = url });
        }

        private void SendSinaWeibo(string content, string url)
        {
            var weiboSessionKeyObj = Session[Helper.PlatformSessionKeyHelper.SinaWeiboSessionKeyName];
            string weiboSessionKey = null;
            if (weiboSessionKeyObj == null)
            {
                if (Session["UID"] == null)
                {
                    throw new Exception("用户名为空");
                }
                int uid = int.Parse(Session["UID"].ToString());
                var pName = Mappings.PlatForm.SinaWeiBo.ToString("G");
                var weiboPF = new OAuthService().QueryPlatforminfo(p => p.UserId == uid && p.Platform == pName);

                if (weiboPF == null)
                {
                    //ViewBag.ErrorMessage = "用户平台信息为空";
                    //return this.View("ShowError");
                    throw new Exception("用户平台信息为空");
                }

                var result = new SinaWeiboService(weiboPF.SessionKey).VerifyAccessToken();

                if (result != TokenResult.Success)
                {
                    throw new Exception("授权无效或已过期，请重新授权。");
                }

                weiboSessionKey = weiboPF.SessionKey;
            }
            else
            {
                weiboSessionKey = weiboSessionKeyObj.ToString();
            }

            ws = new SinaWeiboService(weiboSessionKey);
            ws.Send(new Model.WeiboMessage() { Content = content, Url = url });

        }
    }
}
