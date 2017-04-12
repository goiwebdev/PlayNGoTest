
using PlayNGo.Business.Interface;
using PlayNGo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNGoWeb.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var employeeList = _employeeService.GetAllEmployees();

            return View(employeeList);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employee employee = _employeeService.GetEmployeeById(id.Value);

            if (employee == null)
            {
                return new HttpNotFoundResult();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employee employee = _employeeService.GetEmployeeById(id.Value);

            if (employee == null)
            {
                return new HttpNotFoundResult();
            }

            _employeeService.DeleteEmployee(id.Value);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }


        public ActionResult ChatBox()
        {
            return PartialView("~Views/Home/ChatBox");

        }
    }
}