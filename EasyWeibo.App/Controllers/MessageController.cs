using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyWeibo.App.Controllers
{
    using EasyWeibo.BLL;
    using EasyWeibo.Model;

    public class MessageController : Controller
    {
        //
        // GET: /Message/

        public ActionResult Index()
        {
            var uid = Session["UID"];
            if (uid == null)
            {
                ViewBag.ErrorMessage = "用户ID为空，请确认您是否已授权。";
                return this.View("ShowError");
            }

            var list = new MessageService().GetMessages(1, 10, int.Parse(Session["UID"].ToString()));
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Add(string content, string url)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                ViewBag.ErrorMessage = "信息内容不能为空";
                return this.View("ShowError");
            }

            try
            {
                var message = new message
                {
                    UserId = int.Parse(Session["UID"].ToString()),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Message1 = content,
                    PicUrl = url,
                    PId = 0
                };

                new MessageService().Add(message);
            }
            catch (Exception exception)
            {
                ViewBag.ErrorMessage = exception.InnerException;
                return this.View("ShowError");
            }

            return RedirectToAction("Index");
        }
    }
}
