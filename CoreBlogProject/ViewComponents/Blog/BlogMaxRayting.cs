using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.ViewComponents.Blog
{
    public class BlogMaxRayting : ViewComponent
    {
        BlogRaytingManager brm = new BlogRaytingManager(new EfBlogRaytingRepository());
        public IViewComponentResult Invoke()
        {
            return View(brm.GetList());
        }
    }
}
