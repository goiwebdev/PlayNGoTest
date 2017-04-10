using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNGoWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Employee> employeeList = new List<Employee>();
            using (var db = new EmployeeContext())
            {
                employeeList = db.Employees.ToList();
            }


            return View(employeeList);
        }
    }
}