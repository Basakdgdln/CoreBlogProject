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
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IActionResult Inbox()
        {
            var writerid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(mm.GetInboxListByWriter(writerid));
        }

        public IActionResult Sendbox()
        {
            var writerid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(mm.GetSendboxListByWriter(writerid));
        }

        public PartialViewResult MessageBox()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message2 p)
        {
            var writerid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            p.SenderID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            p.ReceiverID = writerid;
            p.MeesageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.MeesageStatus = true;
            mm.TAdd(p);
            return RedirectToAction("Sendbox");
        }
    }
}
