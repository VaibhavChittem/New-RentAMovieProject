using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RentAMovie.ViewModel;

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

        [HttpGet]
        public ActionResult Create()
        {
            CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel();
            Customer customer = new Customer();
            var membershipTypes = dbContext.MembershipTypes.ToList();
            viewModel.Customer = customer;
            viewModel.MembershipTypes = membershipTypes;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel();
            Customer customer1 = new Customer();
            var membershipTypes = dbContext.MembershipTypes.ToList();
            viewModel.Customer = customer1;
            viewModel.MembershipTypes = membershipTypes;
            return View(viewModel);


        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.Id == id);
            var memTypes = dbContext.MembershipTypes.ToList();
            CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel
            {
                Customer = customer,
                MembershipTypes = memTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var customerTbl = dbContext.Customers.SingleOrDefault(c => c.Id == customer.Id);
            if (customerTbl == null)
            {
                return HttpNotFound();
            }
            else
            {
                customerTbl.Name = customer.Name;
                customerTbl.DateOfBirth = customer.DateOfBirth;
                customerTbl.MembershipTypeId = customer.MembershipTypeId;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Customers");
        }
    }
}