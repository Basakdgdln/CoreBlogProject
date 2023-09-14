using BusinessLayer.Concrete;
using CoreBlogProject.Areas.Admin.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AdminWriterController : Controller
    {
        WriterManager Wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            return View(Wm.GetList());
        }

        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWriter(AddWriterImage p) /*( __tekrar bak)*/
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimage = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimage);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimage;
            }
            w.WriterStatus = true;
            w.WriterName = p.WriterName;
            w.WriterAbout = p.WriterAbout;
            w.WriterMail = p.WriterMail;
            Wm.TAdd(w);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditWriter(int id)
        {
            var writer = Wm.TGetById(id);
            return View(writer);
        }

        [HttpPost]
        public IActionResult EditWriter(Writer p)
        {
            Wm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
