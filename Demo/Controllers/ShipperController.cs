using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Interfaces;

namespace Demo.Controllers
{
    public class ShipperController : Controller
    {
        private IShipperRepository shipperRepository;
        private ILogger logger;

        public ShipperController(IShipperRepository shipperRepository, ILogger log)
        {
            this.shipperRepository = shipperRepository;
            logger = log;
        }

        public ActionResult Index()
        {
            logger.Log("ShipperController Index");

            var shippers = shipperRepository.GetAll();

            return View(shippers);
        }
    }
}
