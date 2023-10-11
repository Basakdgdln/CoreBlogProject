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
    public class AdminCommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            return View(cm.GetCommentWithBlog());
        }

        public IActionResult DeleteComment(int id)
        {
            var commentid = cm.Get(id);
            cm.CommentDelete(commentid);
            return RedirectToAction("Index");
        }

        public IActionResult EditComment(int id)
        {
            var value = cm.Get(id);
            var blog = bm.GetList().Where(x=>x.BlogID==value.BlogID).Select(x => x.BlogTitle).FirstOrDefault();
            ViewBag.blog = blog;
            return View(value);
        }
    }
}
