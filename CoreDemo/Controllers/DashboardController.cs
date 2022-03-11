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
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.blogCount = bm.GetList().Count().ToString();
            ViewBag.writerBlogCount = bm.GetBlogByWriter(1).Count().ToString();
            ViewBag.categoriesCount = cm.GetList().Count.ToString();
            return View();
        }
    }
}
