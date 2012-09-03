using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Demo.Interfaces;
using Demo.Models;
using Demo.ViewModel;

namespace Demo.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private IOrderService orderService;

        public OrderController(IOrderRepository repository, IOrderService service)
        {
            orderRepository = repository;
            orderService = service;
        }

        public ActionResult Index()
        {
            var orders = orderRepository.GetAll();
            return View(orders);
        }

        public ActionResult Details(int Id)
        {
            var order = orderRepository.GetById(Id);

            return View(order);
        }

        public ActionResult Edit(int Id)
        {
            var order = orderService.CreateViewModelForEdit(Id);

            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order_EditViewModel toUpdate)
        {
            var validationErrors = orderService.Update(toUpdate);

            if (validationErrors.Count == 0)
                return RedirectToAction("Details", new { Id = toUpdate.OrderId });

            foreach (var item in validationErrors)
            {
                ModelState.AddModelError(item.Key, item.Value);
            }

            return View(toUpdate);
        }
    }
}
