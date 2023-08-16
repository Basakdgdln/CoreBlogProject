using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    public class EmployeeController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var httpclient = new HttpClient();
            var responsemessage = await httpclient.GetAsync("https://localhost:44388/api/Default");
            var jsonstring = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonstring);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpclient = new HttpClient();
            var jsonemployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonemployee, Encoding.UTF8, "application/json");
            var responsemessage = await httpclient.PostAsync("https://localhost:44388/api/Default", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpclient = new HttpClient();
            var responsemessage = await httpclient.GetAsync("https://localhost:44388/api/Default/" + id);
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonemployee = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonemployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpclient = new HttpClient();
            var jsonemployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonemployee, Encoding.UTF8, "application/json");
            var responsemessage = await httpclient.PutAsync("https://localhost:44388/api/Default", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpclient = new HttpClient();
            var responsemessage = await httpclient.DeleteAsync("https://localhost:44388/api/Default/" + id);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }


    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}


