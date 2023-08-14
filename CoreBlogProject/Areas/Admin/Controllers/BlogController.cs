using ClosedXML.Excel;
using CoreBlogProject.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var x in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = x.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = x.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID=1, BlogName="C# Programlamaya Giriş"},
                new BlogModel{ID=2, BlogName="Tesla Firmasının Araçları"},
                new BlogModel{ID=3, BlogName="2023 Olimpiyatları"}
            };
            return bm;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcellBlogList()
        {
            using (var workbook2 = new XLWorkbook())
            {
                var worksheet2 = workbook2.Worksheets.Add("Blog Listesi");
                worksheet2.Cell(1, 1).Value = "Blog ID";
                worksheet2.Cell(1, 2).Value = "Blog Adı";

                int workbookcountrow = 2;
                foreach (var x in BlogTitleList())
                {
                    worksheet2.Cell(workbookcountrow, 1).Value = x.ID;
                    worksheet2.Cell(workbookcountrow, 2).Value = x.BlogName;
                    workbookcountrow++;
                }
                using (var stream2 = new MemoryStream())
                {
                    workbook2.SaveAs(stream2);
                    var content2 = stream2.ToArray();
                    return File(content2, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }
        }

        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm2 = new List<BlogModel2>();
            using (var c = new Context())
            {
                c.Blogs.Select(x => new BlogModel2
                {
                    ID= x.BlogID,
                    BlogName= x.BlogTitle
                }).ToList();
            }
            return bm2;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
