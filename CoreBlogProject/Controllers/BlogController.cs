using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            return View(bm.GetListWithCategory());
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            return View(bm.GetBlogByID(id));
        }
    }
}
