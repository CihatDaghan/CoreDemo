using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.blogcount = bm.GetList().Count();
            ViewBag.contactcount = c.Contacts.Count();
            ViewBag.commentcount = c.Comments.Count();


            string api = "c1b4d600e929c995facc5b5199f08d45";
            string city = "istanbul";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&appid=" + api;
            XDocument document = XDocument.Load(connection);
            //Descendants= Sutunun adı - //ElementAt= kaçıncı veriyi alacağın - //Attribute= sutun içerisindeki verinin adı
            var temp = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            // Gelen value değeri kelvin olarak geldiği için celciusa çeviriyoruz celceusa çevirmek için gelen datayı 273den çıkartıyoruz.
            var decimaltemp = decimal.Parse(temp, CultureInfo.InvariantCulture);
            var calculatetemp = decimaltemp - 273;
            ViewBag.temp = calculatetemp;
            return View();
        }

    }
}
