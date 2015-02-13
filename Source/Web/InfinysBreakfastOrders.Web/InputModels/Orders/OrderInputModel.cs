using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace InfinysBreakfastOrders.Web.InputModels.Orders
{
    public class OrderInputModel
    {
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [AllowHtml]
        [Display(Name = "Order Text")]
        [DataType(DataType.MultilineText)]
        public string OrderText { get; set; }
    }
}
