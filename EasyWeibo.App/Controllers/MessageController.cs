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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                ViewBag.ErrorMessage = "消息编码错误";
                return this.View("ShowError");
            }

            var message = new MessageService().Single(id);

            return this.View(message);
        }

        [HttpPost]
        public ActionResult Edit(int id, string content, string url)
        {
            if (id <= 0)
            {
                ViewBag.ErrorMessage = "消息编码错误";
                return this.View("ShowError");
            }

            try
            {
                var service = new MessageService();
                var originalMsg = service.Single(id);

                if (originalMsg == null)
                {
                    ViewBag.ErrorMessage = "消息编码错误";
                    return this.View("ShowError");
                }

                originalMsg.Message1 = content;
                originalMsg.PicUrl = url;

                service.Update(originalMsg);

                return this.RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                ViewBag.ErrorMessage = exception.InnerException;
                return this.View("ShowError");
            }
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            if (id <= 0)
            {
                ViewBag.ErrorMessage = "消息编码错误";
                return this.View("ShowError");
            }

            try
            {
                var service = new MessageService();
                var originalMsg = service.Single(id);

                if (originalMsg == null)
                {
                    ViewBag.ErrorMessage = "消息编码错误";
                    return this.View("ShowError");
                }

                originalMsg.State = 127;

                service.Update(originalMsg);

                return this.RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                ViewBag.ErrorMessage = exception.InnerException;
                return this.View("ShowError");
            }
        }
    }
}
