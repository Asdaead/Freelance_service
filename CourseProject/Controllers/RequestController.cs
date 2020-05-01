using CourseProject.Models;
using CourseProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Controllers
{
    public class RequestController : Controller
    {
        AccountContext accountContext = new AccountContext();
        RequestContext requestContext = new RequestContext();

        [HttpGet]
        public IActionResult Add(int orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddRequestModel model)
        {
            var request = new Request
            {
                OrderId = model.OrderId,
                AccountId = accountContext.findIdByLogin(User.Identity.Name),
                Text = model.Text,
                Date = model.Date
            };
            requestContext.Add(request);
            requestContext.SaveChanges();
            return RedirectToAction("Success", "Request");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
