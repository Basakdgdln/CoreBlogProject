using BusinessLayer.Concrete;
using CoreBlogProject.Areas.Admin.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class ChartController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
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
