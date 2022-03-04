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
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());


        [HttpGet]
        public IActionResult Index()
        {
            List<string> city = new List<string>();
            city.Add("İstanbul");
            city.Add("İzmir");
            city.Add("Ankara");
            city.Add("Kayseri");
            ViewBag.city = city;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer w)
        {
                w.WriterStatus = true;
                w.WriterAbout = "Deneme";
                wm.WriterAdd(w);
                return RedirectToAction("Index", "Blog");
        }
    }
}
