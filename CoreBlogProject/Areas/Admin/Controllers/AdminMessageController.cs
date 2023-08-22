using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IActionResult Inbox()
        {
            int writerid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(mm.GetInboxListByWriter(writerid));
        }

        public IActionResult Sendbox()
        {
            int writerid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(mm.GetSendboxListByWriter(writerid));
        }

        public PartialViewResult MessageBox()
        {
            return PartialView();
        }

        public IActionResult ComposeMessage()
        {
            return View();
        }
    }
}
