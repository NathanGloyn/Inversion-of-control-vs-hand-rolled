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
        private ILogger logger;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger log)
        {
            this.employeeRepository = employeeRepository;
            logger = log;
        }

        public ActionResult Index()
        {
            logger.Log("EmployeeController Index");
            var employees = employeeRepository.GetAll();

            return View(employees);
        }

    }
}
