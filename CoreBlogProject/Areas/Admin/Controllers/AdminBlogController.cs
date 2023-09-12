using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    public class AdminBlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            return View(bm.GetListWithCategory());
        }
        public IActionResult BlogDetails(int id)
        {
            CommentManager cm = new CommentManager(new EfCommentRepository());
            var blog = bm.GetListWithCategoryAndWriterById(id);
            ViewBag.d1 = cm.GetList(id).Count();
            return View(blog);
        }

    }
}
