﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.ViewComponents.Writer
{
    public class WriterNavbar : ViewComponent
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var user = userManager.GetList().Where(x => x.UserName == username).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.d = user;
            return View();
        }
    }
}