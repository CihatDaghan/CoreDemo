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
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult PartialAddComment(Comment p)
        {
            if (p.CommentContent!=null && p.CommentUserName != null)
            {
                p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.CommentStatus = true;
                p.BlogID = 2;
                cm.CommentAdd(p);
                return Json(true);
            }
            return Json(false);

        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}
