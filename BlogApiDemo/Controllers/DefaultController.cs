﻿using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Ok(p);
        }

        [HttpGet("{id}")]
        public IActionResult EmployeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpDelete("id")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee p)
        {
            using var c = new Context();
            var employee = c.Employees.Find(p.ID);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                employee.Name = p.Name;
                c.Update(employee);
                c.SaveChanges();
                return Ok(employee);
            }
        }

    }
}

