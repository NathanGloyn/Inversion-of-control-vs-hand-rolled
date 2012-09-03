using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DataAccessLayer.Core;
using Demo.Controllers;
using Demo.DomainLogic;
using Demo.Repositories;

namespace Demo
{
    public class MyControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            var dataAccess = new DataAccess(connectionString);

            var employeeRepository = new EmployeeRepository(dataAccess, Mapper.Engine);
            var customerRepository = new CustomerRepository(dataAccess, Mapper.Engine);
            var shipperRepository = new ShipperRepository(dataAccess, Mapper.Engine);


            if (controllerType == typeof(OrderController))
            {
                var orderRepository = new OrderRepository(dataAccess, Mapper.Engine);
                var orderService = new OrderService(orderRepository, customerRepository, employeeRepository, shipperRepository);
                return new OrderController(orderRepository, orderService);
            }

            if (controllerType == typeof(CustomerController))
            {
                return new CustomerController(customerRepository);
            }

            if (controllerType == typeof(EmployeeController))
            {
                return new EmployeeController(employeeRepository);
            }

            if (controllerType == typeof(ShipperController))
            {
                return new ShipperController(shipperRepository);
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}