using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var id = wm.GetList().Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.blogCount = bm.GetList().Count().ToString();
            ViewBag.writerBlogCount = bm.GetBlogByWriter(id).Count().ToString();
            ViewBag.categoriesCount = cm.GetList().Count.ToString();
            return View();
        }
    }
}
