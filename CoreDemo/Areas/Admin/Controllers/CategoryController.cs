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
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetList().ToPagedList(page, 3);
            return View(values);
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            //Category eklemek için validasyon işlemi yapılıyor
            CategoryValidator bv = new CategoryValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            //
            return View();
        }
        public IActionResult CategoryMakePassive(int id)
        {
            var values = cm.TGetByID(id);
            values.CategoryStatus = false;
            cm.TUpdate(values);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryMakeActive(int id)
        {
            var values = cm.TGetByID(id);
            values.CategoryStatus = true;
            cm.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}
