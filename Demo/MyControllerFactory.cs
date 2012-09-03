﻿using System;
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

            var orderRepository = new OrderRepository(dataAccess, Mapper.Engine);
            var customerRepository = new CustomerRepository(dataAccess, Mapper.Engine);
            var employeeRepository = new EmployeeRepository(dataAccess, Mapper.Engine);
            var shipperRepository = new ShipperRepository(dataAccess, Mapper.Engine);

            var orderService = new OrderService(orderRepository, customerRepository, employeeRepository, shipperRepository);

            if (controllerType == typeof(OrderController))
                return new OrderController(orderRepository, orderService);

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}