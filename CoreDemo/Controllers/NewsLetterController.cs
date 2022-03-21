using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscrideMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter p)
        {
            var data = nm.GetList().Where(x => x.Mail == p.Mail).Count();
            if (data == 0)
            {
            if (p.Mail != null)
            {
                p.MailStatus = true;
                nm.TAdd(p);
                return View();
            }
            }
            return View();
        }
    }
}
