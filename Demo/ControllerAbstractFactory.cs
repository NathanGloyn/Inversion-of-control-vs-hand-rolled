using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DataAccessLayer.Core;
using DataAccessLayer.Interfaces;
using Demo.Controllers;
using Demo.DomainLogic;
using Demo.Interfaces;
using Demo.Repositories;

namespace Demo
{
    public class ControllerAbstractFactory
    {
        internal static ILogger _logger;
        internal static string _connectionString;
     
        internal Dictionary<Type, Func<Controller>> functionMap;

        IDataAccess dataAccess;

        public ControllerAbstractFactory()
        {
            functionMap = new Dictionary<Type, Func<Controller>>
            {
                {typeof(OrderController), CreateOrderController},
                {typeof(CustomerController), CreateCustomerController},
                {typeof(EmployeeController), CreateEmployeeController},
                {typeof(ShipperController), CreateShipperController}
            };

        }

        private ILogger Log
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger();
                }

                return _logger;
            }
        }

        private string ConnectionString 
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString= ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
                }

                return _connectionString;
            }
        }

        public Controller Create(Type toCreate)
        {
            dataAccess = new DataAccess(ConnectionString);
            
            return functionMap[toCreate]();
        }

        private Controller CreateOrderController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            var dataAccess = new DataAccess(connectionString);

            var employeeRepository = new EmployeeRepository(dataAccess, Mapper.Engine);
            var customerRepository = new CustomerRepository(dataAccess, Mapper.Engine);
            var shipperRepository = new ShipperRepository(dataAccess, Mapper.Engine);


            var orderRepository = new OrderRepository(dataAccess, Mapper.Engine);
            var orderService = new OrderService(orderRepository, customerRepository, employeeRepository, shipperRepository, Log);

            return (Controller) new OrderController(orderRepository, orderService, Log);
        }

        private Controller CreateCustomerController()
        {
            var customerRepository = new CustomerRepository(dataAccess, Mapper.Engine);

            return new CustomerController(customerRepository, Log);
        }

        private Controller CreateEmployeeController()
        {
            var employeeRepository = new EmployeeRepository(dataAccess, Mapper.Engine);

            return new EmployeeController(employeeRepository, Log);
        }

        private Controller CreateShipperController()
        {
            var shipperRepository = new ShipperRepository(dataAccess, Mapper.Engine);

            return new ShipperController(shipperRepository, Log);
        }
    }
}