using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscrideMail()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult SubscribeMail(NewsLetter p)
        {
            if (p.Mail != null)
            {
                p.MailStatus = true;
                nm.AddNewsLetter(p);
                return Json(true);
            }
            return Json(false);
        }
    }
}
