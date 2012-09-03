using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Interfaces;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public ActionResult Index()
        {
            var employees = employeeRepository.GetAll();
            
            return View(employees);
        }

    }
}
