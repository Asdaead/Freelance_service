using CourseProject.Models;
using CourseProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Controllers
{
    public class OrderController : Controller
    {
        OrderContext orderContext = new OrderContext();
        readonly AccountContext accountContext = new AccountContext();
        RequestContext requestContext = new RequestContext();
        readonly CategoryContext categoryContext = new CategoryContext();
        [HttpGet]
        public IActionResult Index(int id)
        {
            var order = orderContext.Orders.ToList().Where(x => x.Id == id).First();
            var userId = accountContext.findIdByLogin(User.Identity.Name);
            ViewBag.Order = order;
            ViewBag.UserId = userId;
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = new SelectList(categoryContext.Categories.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddOrderModel model)
        {
            var orderToAdd = new Order {
                AccountId = accountContext.findIdByLogin(User.Identity.Name),
                ShortDesc = model.ShortDesc,
                LongDesc = model.LongDesc,
                Price = model.Price,
                Date = model.Date,
                CategoryId = model.CategoryId
            };

            orderContext.Add(orderToAdd);
            orderContext.SaveChanges();

            return RedirectToAction("Success", "Order");
        }
        [HttpGet]
        public IActionResult Update(int orderId)
        {
            var order = orderContext.Orders.ToList().Where(x => x.Id == orderId).First();
            ViewData["Order"] = order;
            return View();
        }
        [HttpPost]
        public IActionResult Update(AddOrderModel model)
        {
            var orderToEdit = orderContext.Orders.ToList().Where(x => x.Id == model.OrderId).First();
            orderContext.Update(orderToEdit);

            orderToEdit.ShortDesc = model.ShortDesc;
            orderToEdit.LongDesc = model.LongDesc;
            orderToEdit.Price = model.Price;
            orderToEdit.CategoryId = model.CategoryId;

            orderContext.SaveChanges();

            return RedirectToAction("Success", "Order");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
