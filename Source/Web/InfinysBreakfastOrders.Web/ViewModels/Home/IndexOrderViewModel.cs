using InfinysBreakfastOrders.Data.Models;
using InfinysBreakfastOrders.Web.Infastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinysBreakfastOrders.Web.ViewModels.Home
{
    public class IndexOrderViewModel : IMapFrom<Order>
    {
        public string Username { get; set; }

        public string OrderText { get; set; }
    }
}