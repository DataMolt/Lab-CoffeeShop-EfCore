using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_CoffeeShop_EFCore.Models;
using Lab_CoffeeShop_EFCore.Data;
using Microsoft.AspNetCore.Http;

namespace Lab_CoffeeShop_EFCore.Controllers
{
    public class HomeController : Controller
    {
        private CoffeeShopContext _coffeeShopContext;
        private readonly ISession _session;

        public HomeController(CoffeeShopContext coffeeShopContext, IHttpContextAccessor httpContextAccessor)
        {
            _coffeeShopContext = coffeeShopContext;
            _session = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(User registration)
        {
            if (!ModelState.IsValid)
            {
                return View(registration);
            }

            _coffeeShopContext.Users.Add(registration);
            _coffeeShopContext.SaveChanges();

            return RedirectToAction("Index", "Home", registration);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User login)
        {
            var userName = login.UserName;
            var password = login.Password;

            var foundUser = _coffeeShopContext.Users.Where(u => u.UserName == userName).Where(u => u.Password == password).FirstOrDefault();

            if (foundUser != null)
            {
                _session.SetString("User", foundUser.UserName);
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Login. Please try again.";
                return View();
            }

            return View("Index");
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
