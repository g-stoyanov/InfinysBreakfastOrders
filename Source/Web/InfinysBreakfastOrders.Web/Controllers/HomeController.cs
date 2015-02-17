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
using System.Data.Entity;

namespace InfinysBreakfastOrders.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDeletableEntityRepository<Order> orders;

        public HomeController(IDeletableEntityRepository<Order> orders)
        {
            this.orders = orders;
        }

        [Authorize]
        public ActionResult Index()
        {
            //this.orders.Delete(1);
            //this.orders.SaveChanges();
            var currentOrders = from order in this.orders.All()
                                where DbFunctions.TruncateTime(order.OrderDate) == DbFunctions.TruncateTime(DateTime.Now)
                select order;

            var orders = currentOrders.Project().To<IndexOrderViewModel>();           
            
            return View(orders);
        }
    }
}