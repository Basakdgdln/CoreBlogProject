using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.ViewComponents.Blog
{
    public class SameTypeBlog : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.id = id;
            var categoryid = bm.GetBlogByID(id).Select(x => x.CategoryID).FirstOrDefault();
            return View(bm.GetList().Where(x => x.CategoryID == categoryid).OrderByDescending(x=>x.BlogCreateDate).TakeLast(4).ToList());
        }
    }
}
