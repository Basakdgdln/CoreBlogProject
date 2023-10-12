using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.Controllers
{
    public class AdminProfileController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminRepository());

        [AllowAnonymous]
        [HttpGet]
        [Area("Admin")]
        public IActionResult AdminProfile(int id)
        {
            Context c = new Context();
            var admin = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //var username = User.Identity.Name;
            //var user = c.Adminns.Where(x => x.Username == username).Select(x => x.AdminID).FirstOrDefault();
            var values = adm.TGetById(admin);
            return View(values);
        }
    }
}
