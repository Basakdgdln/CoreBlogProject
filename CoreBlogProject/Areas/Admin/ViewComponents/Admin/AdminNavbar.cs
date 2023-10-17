using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.ViewComponents
{
    public class AdminNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var admin = c.Users.Where(x => x.UserName == username).Select(x => x.NameSurname).FirstOrDefault();
            ViewBag.admin = admin;
            return View();
        }
    }
}
