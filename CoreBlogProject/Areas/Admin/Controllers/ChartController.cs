using CoreBlogProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categorycount = 10,
                categoryname = "Teknoloji"
            });
            list.Add(new CategoryClass
            {
                categorycount = 14,
                categoryname = "Yazılım"
            });
            list.Add(new CategoryClass
            {
                categorycount = 5,
                categoryname = "Spor"
            });
            list.Add(new CategoryClass
            {
                categorycount = 2,
                categoryname = "Sinema"
            });
            return Json(new { jsonlist = list });
        }
    }
}
