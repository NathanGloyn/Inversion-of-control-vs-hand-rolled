using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Interfaces;

namespace Demo.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository customerRepository;
        private ILogger logger;

        public CustomerController(ICustomerRepository customerRepository, ILogger log)
        {
            this.customerRepository = customerRepository;
            logger = log;
        }

        public ActionResult Index()
        {
            logger.Log("Customer Index");

            var customers = customerRepository.GetAll();

            return View(customers);
        }

    }
}
