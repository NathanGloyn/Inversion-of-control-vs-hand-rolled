using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Interfaces;
using Demo.Models;
using Demo.ViewModel;

namespace Demo.DomainLogic
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;
        private IEmployeeRepository employeeRepository;
        private ICustomerRepository customerRepository;
        private IShipperRepository shiperRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IEmployeeRepository employeeRepository, IShipperRepository shiperRepository)
        {
            this.orderRepository = orderRepository;
            this.employeeRepository = employeeRepository;
            this.customerRepository = customerRepository;
            this.shiperRepository = shiperRepository;
        }

        public Order_EditViewModel CreateViewModelForEdit(int Id)
        {
            var order = orderRepository.GetDomainObjectById(Id);
            var employees = employeeRepository.GetAll();
            var shippers = shiperRepository.GetAll();
            var customers = customerRepository.GetAll();

            var viewModel = new Order_EditViewModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                ShipVia = order.ShipVia,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                Employee = employees,
                Shippers = shippers,
                Customer = customers
            };

            return viewModel;
        }

        public Dictionary<string, string> Update(Order_EditViewModel toUpdate)
        {
            var validationErrors = ValidateModel(toUpdate);

            if (validationErrors.Count == 0)
                orderRepository.Update(toUpdate);

            return validationErrors;
        }

        private static Dictionary<string, string> ValidateModel(Order_EditViewModel toUpdate)
        {
            var validationErrors = new Dictionary<string, string>();

            if (toUpdate.RequiredDate <= toUpdate.OrderDate)
                validationErrors.Add("RequiredDate", "Cannot be before the Order Date");

            if (toUpdate.ShippedDate <= toUpdate.OrderDate)
                validationErrors.Add("ShippedDate", "Cannot be before the Order Date");

            return validationErrors;
        }
    }
}           
