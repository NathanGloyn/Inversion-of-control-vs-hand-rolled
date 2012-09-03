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

        public ShipperController(IShipperRepository shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }

        //
        // GET: /Shipper/

        public ActionResult Index()
        {
            var shippers = shipperRepository.GetAll();

            return View(shippers);
        }

    }
}
