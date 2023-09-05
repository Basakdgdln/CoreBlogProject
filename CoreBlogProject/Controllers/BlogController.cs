using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreBlogProject.Controllers
{

    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();

        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
            return View(bm.GetListWithCategory().ToPagedList(page, 8));
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            return View(bm.GetListWithCategoryAndWriterById(id));
        }

        public IActionResult BlogListByWriter()
        {
            var writerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(bm.GetListWithCategoryByWriterBm(writerID));
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> category = (from x in cm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.d1 = category;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var writerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            BlogValidator validationRules = new BlogValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var value = bm.TGetById(id);
            bm.TDelete(value);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var value = bm.TGetById(id);
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> category = (from x in cm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.d1 = category;
            return View(value);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {

            var writerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            BlogValidator validationRules = new BlogValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                bm.TUpdate(p);
                return RedirectToAction("BlogListByWriter");
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult GetCategoryBlog(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            var values = bm.GetListWithCategory().Where(x => x.CategoryID == id).ToList();
            var writer = cm.GetList().Where(x => x.CategoryID == id).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.category = writer;
            return View(values);
        }

        [HttpGet]
        public PartialViewResult ContainsBlog()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ContainsBlog(string p)
        {
            var blogs = (from x in bm.GetList() select x);
            if (string.IsNullOrEmpty(p))
            {
                blogs = blogs.Where(x => x.BlogTitle.Contains(p)).ToList();
            }
            return View(blogs);
        }
    }
}
