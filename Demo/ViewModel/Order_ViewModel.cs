using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.ViewModel
{
    public class Order_ViewModel
    {
        public int OrderId { get; set; }
        public string ShipVia { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Customer { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime RequiredDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public string EmployeeName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}