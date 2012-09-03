using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Demo.Interfaces;
using Demo.Models;

namespace Demo.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;

        public OrderController(IOrderRepository repository)
        {
            orderRepository = repository;
        }

        public ActionResult Index()
        {
            var orders = orderRepository.GetAll();
            return View(orders);
        }
    }
}
