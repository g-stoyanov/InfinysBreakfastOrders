using InfinysBreakfastOrders.Web.InputModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfinysBreakfastOrders.Web.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }


        // GET-POST-REDIRECT PATTERN
        [HttpGet]
        public ActionResult NewOrder()
        {
            return Content("GET");
        }

        [HttpPost]
        public ActionResult NewOrder(OrderInputModel input)
        {
            return Content("POST");
        }
    }
}