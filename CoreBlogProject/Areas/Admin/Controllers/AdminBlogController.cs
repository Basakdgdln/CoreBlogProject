using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreBlogProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index(int page = 1)
        {
            return View(bm.GetListWithCategory().ToPagedList(page, 8));
        }
        public IActionResult BlogDetails(int id)
        {
            CommentManager cm = new CommentManager(new EfCommentRepository());
            var blog = bm.GetListWithCategoryAndWriterById(id);
            TempData["blogid"] = blog;
            ViewBag.d1 = cm.GetList(id).Count();
            return View(blog);
        }

        public IActionResult BlogCommment(int id)
        {
            id = (int)TempData["blogid"];
            ViewBag.blogid = id;
            CommentManager cm = new CommentManager(new EfCommentRepository());
            cm.GetList(id);
            return PartialView();
        }
    }
}
