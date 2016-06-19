using MyWebShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.ViewModels
{
    public class EditOrderViewModel
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }

        public EditOrderViewModel()
        {
        }

        public EditOrderViewModel(OrderPart order)
        {
            Id = order.Id;
            Status = order.Status;
        }
    }
}