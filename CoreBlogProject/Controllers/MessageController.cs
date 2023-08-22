using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    public class MessageController : Controller
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
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            ViewBag.d = 1;
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var writerid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            p.SenderID = writerid;
            p.ReceiverID = 2;
            p.MeesageStatus = true;
            p.MeesageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("Inbox");
        }
    }
}