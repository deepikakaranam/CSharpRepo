using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private ECommerceContext dbContext;
        public HomeController (ECommerceContext context)
        {
            dbContext = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            var customers= dbContext.Customers.Where(c =>c.CustomerId<=5).ToList();

            ViewBag.Customers=customers;
            var products = dbContext.Products.Where(p =>p.ProductId<=6).ToList();
            ViewBag.Products= products;
            var orders = dbContext.Orders.Include(o =>o.CustomerOrdered).
            Include(o =>o.OrderedProduct).Where(o =>o.OrderId<=6).ToList();
            ViewBag.Orders= orders;

           
            return View();
        }
        [HttpGet("orders")]
        public IActionResult Orders()
        {
            var customers= dbContext.Customers.ToList();
            ViewBag.Customers=customers;
            var products = dbContext.Products.ToList();
            ViewBag.Products= products;
            var orders = dbContext.Orders.Include(o =>o.CustomerOrdered).
                    Include(o =>o.OrderedProduct).ToList();
            ViewBag.Orders = orders;
            return View();
        }
        [HttpGet("customers")]
        public IActionResult Customers()
        {
            
           var customers = dbContext.Customers.ToList();
           ViewBag.Customers = customers;
            return View();
        }
        [HttpGet("products")]
        public IActionResult Products()
        {
            var products = dbContext.Products.ToList();
            ViewBag.Products = products;
            return View();
        }
        [HttpGet("settings")]
        public IActionResult Settings()
        {
            return View();
        }
        
        [HttpPost("createCustomer")]
        public IActionResult CreateCustomer(Customer customer)
        {
            dbContext.Add(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Customers");
        }
        [HttpPost("createProduct")]
        public IActionResult CreateProduct(Product product)
        {
            dbContext.Add(product);
            dbContext.SaveChanges();
            return RedirectToAction("Products");
        }
         [HttpPost("createOrder")]
        public IActionResult CreateOrder(Order order)
        {
            dbContext.Add(order);
            dbContext.SaveChanges();
            return RedirectToAction("Orders");
        }






    }
}
