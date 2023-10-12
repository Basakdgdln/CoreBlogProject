using BusinessLayer.Concrete;
using CoreBlogProject.Areas.Admin.Models;
using DataAccessLayer.Concrete;
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

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult BlogRaytingChart()
        {
            return Json(new { jsonlist = TotalBlogRaytingList() });
        }
        public List<TotalBlogRayting> TotalBlogRaytingList()
        {
            List<TotalBlogRayting> tbr = new List<TotalBlogRayting>();
            using (var c = new Context())
            {
                var blogs = from x in c.Blogs
                            join y in c.BlogRaytings
                            on x.BlogID equals y.BlogID
                            select new
                            {
                                blog = x.BlogTitle,
                                rayting = y.BlogTotalScore
                            };

                tbr = blogs.Select(x => new TotalBlogRayting
                {
                    blog = x.blog,
                    totalrayting = x.rayting
                }).ToList();
            }
            return tbr;
        }
    }
}
