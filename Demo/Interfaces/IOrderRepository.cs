using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.ViewModel;

namespace Demo.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order_ViewModel> GetAll();
        Order_ViewModel GetById(int Id);
        Order GetDomainObjectById(int Id);
        void Update(Order_EditViewModel toUpdate);
    }
}

