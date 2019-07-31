using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_CoffeeShop_EFCore.Models;
using Lab_CoffeeShop_EFCore.Data;

namespace Lab_CoffeeShop_EFCore.Controllers
{
    public class ProductController : Controller
    {
        private CoffeeShopContext _coffeeShopContext;

        public ProductController(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            var productsToDisplay = _coffeeShopContext.Products;

            return View(productsToDisplay);
        }

        public IActionResult Edit(int id)
        {
            var productToEdit = _coffeeShopContext.Products.Find(id);
            return View(productToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Product product, int id)
        {
            var productToEdit = _coffeeShopContext.Products.Find(id);

            productToEdit.Name = product.Name;
            productToEdit.Price = product.Price;
            productToEdit.Quantity = product.Quantity;
            productToEdit.Description = product.Description;

            _coffeeShopContext.SaveChanges();

            return RedirectToAction("Products", "Product");
        }

        public IActionResult Delete(int id)
        {
            var productToDelete = _coffeeShopContext.Products.Find(id);

            _coffeeShopContext.Products.Remove(productToDelete);
            _coffeeShopContext.SaveChanges();

            return RedirectToAction("Products", "Product");
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _coffeeShopContext.Products.Add(product);
            _coffeeShopContext.SaveChanges();

            return RedirectToAction("Products", "Product");
        }
    }
}