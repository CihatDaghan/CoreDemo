using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        WriterManager wm = new WriterManager(new EfWriterRepository());

        public IActionResult Inbox()
        {
            var usermail = User.Identity.Name;
            var id = wm.GetList().Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }
        public IActionResult GetMessageDetails(int id)
        {
            var values = mm.TGetByID(id);
            return View(values);
        }
    }
}
