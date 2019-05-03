using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RentAMovie.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public CustomersController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> Customers = dbContext.Customers.Include(m => m.MembershipType).ToList();
            return View(Customers);
        }

        public ActionResult Details(int id)
        {
            var customer = dbContext.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{Id = 1,Name="Dhanu",DateOfBirth=DateTime.Now},
                new Customer{Id = 2, Name ="Nani",DateOfBirth=Convert.ToDateTime("01/09/1995") }
            };
            return customers;
        }

        public ActionResult Create()
        {

            return View();
        }
    }
}