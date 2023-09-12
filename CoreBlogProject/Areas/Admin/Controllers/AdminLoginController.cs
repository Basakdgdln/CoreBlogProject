using BusinessLayer.Concrete;
using CoreBlogProject.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AdminLoginController : Controller
    {
        private readonly SignInManager<Adminn> _signInManager1;
        public AdminLoginController(SignInManager<Adminn> signInManager1)
        {
            _signInManager1 = signInManager1;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminSıgnInModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager1.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "AdminBlog");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
