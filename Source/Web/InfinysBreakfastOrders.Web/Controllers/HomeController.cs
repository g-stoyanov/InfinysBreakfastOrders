using InfinysBreakfastOrders.Data;
using InfinysBreakfastOrders.Data.Common.Repository;
using InfinysBreakfastOrders.Data.Models;
using InfinysBreakfastOrders.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;

namespace InfinysBreakfastOrders.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Order> orders;

        public HomeController(IRepository<Order> orders)
        {
            this.orders = orders;
        }

        public ActionResult Index()
        {
            var orders = this.orders.All().Project().To<IndexOrderViewModel>();

            return View(orders);
        }
    }
}