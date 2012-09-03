using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.ViewModel
{
    public class Order_EditViewModel
    {
        public int OrderId { get; set; }
        public int ShipVia { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        
        [Required(ErrorMessage="You must provide a date the order was placed")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequiredDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ShippedDate { get; set; }
        
        public decimal Freight { get; set; }
        
        [StringLength(40)]
        public string ShipName { get; set; }
        
        [StringLength(60)]
        public string ShipAddress { get; set; }
        
        [StringLength(15)]
        public string ShipCity { get; set; }

        [StringLength(15)]
        public string ShipRegion { get; set; }

        [StringLength(10)]
        public string ShipPostalCode { get; set; }

        [StringLength(15)]
        public string ShipCountry { get; set; }
        
        public IEnumerable<Shipper> Shippers { get; set; }
        public IEnumerable<Employee> Employee { get; set; }
        public IEnumerable<Customer> Customer { get; set; }
    }
}