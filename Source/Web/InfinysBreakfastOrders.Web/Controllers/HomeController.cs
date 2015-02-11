using InfinysBreakfastOrders.Data;
using InfinysBreakfastOrders.Data.Common.Repository;
using InfinysBreakfastOrders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfinysBreakfastOrders.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Order> orders;

        // Poor man's DI
        public HomeController()
            : this(new GenericRepository<Order>(new ApplicationDbContext()))
        {

        }

        public HomeController(IRepository<Order> orders)
        {
            this.orders = orders;
        }

        public ActionResult Index()
        {
            var orders = this.orders.All();

            return View(orders);
        }
    }
}