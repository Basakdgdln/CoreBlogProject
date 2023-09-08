using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.ViewComponents.Writer
{
    public class LoginWriterName:ViewComponent
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var user = userManager.GetList().Where(x => x.UserName == username).Select(x => x.NameSurname).FirstOrDefault();
            var image = userManager.GetList().Where(x => x.UserName == username).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.d = user;
            ViewBag.image = image;
            return View();
        }
    }
}
