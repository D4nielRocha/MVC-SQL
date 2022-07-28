using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDB_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDB_Demo.Controllers
{
    public class Employee12Controller : Controller
    {

        EmployeeDBAccessLayer empdb = new EmployeeDBAccessLayer();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] EmployeeEntities employeeEntities)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    string resp = empdb.AddEmployeeRecord(employeeEntities);
                    TempData["msg"] = resp;
                }

            }catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return View();
        }
    }
}
