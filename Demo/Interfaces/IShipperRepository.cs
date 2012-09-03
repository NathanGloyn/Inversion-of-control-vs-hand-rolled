using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Models;

namespace Demo.Interfaces
{
    public interface IShipperRepository
    {
        IEnumerable<Shipper> GetAll();
        Shipper GetById(int Id);
    }
}
