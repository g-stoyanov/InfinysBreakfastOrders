using InfinysBreakfastOrders.Data.Common.Repository;
using InfinysBreakfastOrders.Data.Models;
using InfinysBreakfastOrders.Web.InputModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using InfinysBreakfastOrders.Web.ViewModels.Home;
using AutoMapper.QueryableExtensions;
using InfinysBreakfastOrders.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InfinysBreakfastOrders.Web.Controllers
{
    public class OrdersController : Controller
    {
        private IDeletableEntityRepository<Order> orders;

        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected UserManager<ApplicationUser> UserManager { get; set; }

        public OrdersController(IDeletableEntityRepository<Order> orders)
        {
            this.orders = orders;
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
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

        [Authorize]
        public ActionResult MyOrders()
        {
            //this.orders.Delete(1);
            //this.orders.SaveChanges();

            var user = this.UserManager.FindById(User.Identity.GetUserId());
            var currentOrders = from order in this.orders.All()
                                where order.User == user
                                select order;

            var orders = currentOrders.Project().To<IndexOrderViewModel>();

            return View(orders);
        }
    }
}