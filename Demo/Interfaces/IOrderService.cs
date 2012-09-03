using System;
using System.Collections.Generic;
using HandRolled.Models;
using HandRolled.ViewModel;

namespace HandRolled.Interfaces
{
    public interface IOrderService
    {
        Order_EditViewModel CreateViewModelForEdit(int Id);
        Dictionary<string, string> Update(Order_EditViewModel toUpdate);
    }
}
