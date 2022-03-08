using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
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
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(w);
            if (results.IsValid)
            {
                w.WriterStatus = true;
                w.WriterAbout = "Deneme";
                wm.WriterAdd(w);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            List<string> city = new List<string>();
            city.Add("İstanbul");
            city.Add("İzmir");
            city.Add("Ankara");
            city.Add("Kayseri");
            ViewBag.city = city;
            return View();
          
        }
    }
}
