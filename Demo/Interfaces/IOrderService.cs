using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.ViewModel;

namespace Demo.Interfaces
{
    public interface IOrderService
    {
        Order_EditViewModel CreateViewModelForEdit(int Id);
        Dictionary<string, string> Update(Order_EditViewModel toUpdate);
    }
}
