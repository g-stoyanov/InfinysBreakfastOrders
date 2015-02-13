using InfinysBreakfastOrders.Data.Common.Repository;
using InfinysBreakfastOrders.Data.Models;
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
        private IDeletableEntityRepository<Order> orders;

        public OrdersController(IDeletableEntityRepository<Order> orders)
        {
            this.orders = orders;
        }

        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }


        // GET-POST-REDIRECT PATTERN
        [HttpGet]
        public ActionResult NewOrder()
        {
            var model = new OrderInputModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult NewOrder(OrderInputModel input)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                    {
                        OrderDate = input.OrderDate,
                        OrderText = input.OrderText
                    };

                this.orders.Add(order);
                this.orders.SaveChanges();

                this.RedirectToAction("Index", "Home");
            }

            return this.View(input);
        }
    }
}