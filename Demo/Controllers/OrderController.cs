using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Interfaces;
using Demo.ViewModel;

namespace Demo.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private IOrderService orderService;
        private ILogger logger;

        public OrderController(IOrderRepository repository, IOrderService service, ILogger log)
        {
            orderRepository = repository;
            orderService = service;
            logger = log;
        }

        public ActionResult Index()
        {
            logger.Log("OrderController Index");

            var orders = orderRepository.GetAll();
            return View(orders);
        }

        public ActionResult Details(int Id)
        {
            logger.Log("OrderController Details");

            var order = orderRepository.GetById(Id);

            return View(order);
        }

        public ActionResult Edit(int Id)
        {
            logger.Log("OrderController Edit");

            var order = orderService.CreateViewModelForEdit(Id);

            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order_EditViewModel toUpdate)
        {
            logger.Log("OrderController Edit:Update");

            var validationErrors = orderService.Update(toUpdate);

            if (validationErrors.Count == 0)
            {
                logger.Log("OrderController Edit:Update - Sucessful update");
                return RedirectToAction("Details", new { Id = toUpdate.OrderId });
            }

            logger.Log("OrderController Edit:Update - validation errors");

            foreach (var item in validationErrors)
            {
                ModelState.AddModelError(item.Key, item.Value);
            }

            return View(toUpdate);
        }
    }
}
