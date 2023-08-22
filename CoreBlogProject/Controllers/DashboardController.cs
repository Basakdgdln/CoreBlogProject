using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x=>x.UserName== username).Select(y=>y.Email).FirstOrDefault() ;
            var writerid = c.Writers.Where(x=>x.WriterMail==usermail).Select(y=>y.WriterID).FirstOrDefault();
            ViewBag.d1 = bm.GetList().Count();       
            ViewBag.d2 = bm.GetListWithWriter(writerid).Count();
            ViewBag.d3 = c.Categories.Count();
            ViewBag.d4 = writerid;
            return View();
        }
    }
}
