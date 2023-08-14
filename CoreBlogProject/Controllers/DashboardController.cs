using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            BlogManager bm = new BlogManager(new EfBlogRepository());
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            ViewBag.d1 = bm.GetList().Count();
            ViewBag.d2 = bm.GetListWithWriter(1).Count();
            ViewBag.d3 = cm.GetList().Count();
            return View();
        }
    }
}
