using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseProject.Models;
using CourseProject.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        AccountContext accountContext = new AccountContext();
        OrderContext orderContext = new OrderContext();
        RequestContext requestContext = new RequestContext();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Account> account = accountContext.Accounts.ToList().Where(x => x.Email == model.Login || x.Login == model.Login && x.Password == model.Password);
                if (account.Any())
                {
                    await Authenticate(account.First().Login); 

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var accountToAdd = new Account
                {
                    Email = model.Email,
                    Login = model.Login,
                    Password = model.Password
                };
                accountContext.Add(accountToAdd);
                accountContext.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                return View(model);
            }
        }

        private async Task Authenticate(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public IActionResult Personal(string username)
        {
            var accountData = accountContext.Accounts.ToList().Where(x => x.Login == username).First();
            var accountOrders = orderContext.Orders.ToList().Where(x => x.AccountId == accountData.Id);
            var accountRequests = requestContext.getAccountRequests(User.Identity.Name);
            var accountOrdersRequests = requestContext.getOrdersRequest(User.Identity.Name);
            ViewBag.Orders = accountOrders;
            ViewBag.Account = accountData;
            ViewBag.Requests = accountRequests;
            ViewBag.OrdersRequest = accountOrdersRequests;
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
