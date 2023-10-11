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
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1)
        {
            return View(bm.GetListWithCategory().ToPagedList(page, 8));
        }
        public IActionResult BlogDetails(int id)
        {
            CommentManager cm = new CommentManager(new EfCommentRepository());
            var blog = bm.GetListWithCategoryAndWriterById(id);
            ViewBag.d1 = cm.GetList(id).Count();
            return View(blog);
        }

        //public PartialViewResult BlogComment(int id)
        //{
        //    var blog = bm.GetListWithCategoryAndWriterById(id);
        //    ViewBag.id = blog;
        //                        return PartialView();
        //}

    }
}
