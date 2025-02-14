﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CourseProject.Models;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        OrderContext orderContext = new OrderContext();
        AccountContext accountContext = new AccountContext();

        public IActionResult Index()
        {
            IEnumerable<Order> allOrders = orderContext.Orders.ToList().OrderByDescending(x => x.Date);
            var userId = accountContext.findIdByLogin(User.Identity.Name);
            ViewBag.UserId = userId;
            ViewBag.Orders = allOrders;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
