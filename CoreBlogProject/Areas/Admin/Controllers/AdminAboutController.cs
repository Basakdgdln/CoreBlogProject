using BusinessLayer.Concrete;
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
    public class AdminAboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            return View(abm.GetList());
        }

        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var value = abm.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditAbout(About p)
        {
            abm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
