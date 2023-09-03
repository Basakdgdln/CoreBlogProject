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
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(abm.GetList());
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
