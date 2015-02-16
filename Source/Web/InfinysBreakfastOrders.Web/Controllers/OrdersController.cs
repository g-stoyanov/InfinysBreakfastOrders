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
using System.Data.Entity.Core.Objects;
using InfinysBreakfastOrders.Web.Infastructure;

namespace InfinysBreakfastOrders.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IDeletableEntityRepository<Order> orders;

        private readonly IDeletableEntityRepository<ApplicationUser> users;

        private readonly ISanitizer sanitizer;

        public OrdersController(IDeletableEntityRepository<Order> orders, IDeletableEntityRepository<ApplicationUser> users, ISanitizer sanitizer)
        {
            this.orders = orders;
            this.users = users;
            this.sanitizer = sanitizer;
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

        [Authorize]
        [HttpPost]
        public ActionResult NewOrder(OrderInputModel input)
        {

            if (ModelState.IsValid)
            {
                var currUserId = User.Identity.GetUserId();

                var user = (from u in this.users.All()
                            where u.Id == currUserId
                            select u).FirstOrDefault();

                var orderWithSameDate = (from o in user.Orders
                                        where o.OrderDate.Date == input.OrderDate.Date
                                        select o).FirstOrDefault();

                if (orderWithSameDate != null)
                {
                    return this.View(input);
                }

                var order = new Order
                    {
                        AuthorId = currUserId,
                        OrderDate = input.OrderDate,
                        OrderText = sanitizer.Sanitize(input.OrderText)
                    };

                this.orders.Add(order);
                this.orders.SaveChanges();

                this.RedirectToAction("Home", "Index");
            }

            return this.View(input);
        }

        [Authorize]
        public ActionResult MyOrders()
        {
            //this.orders.Delete(1);
            //this.orders.SaveChanges();
            var currUserId = User.Identity.GetUserId();
            var user = (from u in this.users.All()
                        where u.Id == currUserId
                        select u).FirstOrDefault();


            var orders = user.Orders.OrderByDescending(o => o.OrderDate);

            return View(orders);
        }
    }
}