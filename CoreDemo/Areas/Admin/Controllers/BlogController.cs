using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportExcelBlogList()
        {
            //Bloglar excele indiriliyor.
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;

                }
                using (var stream= new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Bloglar.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            //blog listesi geliyor ve model ile eşleniyor
            List<BlogModel> bm = new List<BlogModel>();
            using (var c=new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel
                {
                    ID=x.BlogID,
                    BlogName=x.BlogTitle
                }).ToList(); 
            }
            return bm;
        }
      
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
