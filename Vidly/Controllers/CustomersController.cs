 using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DbContexts;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyDb db;

        public CustomersController()
        {
            db = new VidlyDb();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();

            return View(customers);
        }

        // GET: Customers/Details/id
        public ActionResult Details(int id)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // GET: Customers/New
        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = db.MembershipTypes.ToList()
            };

            return View(viewModel);
        }

        // GET: Customers/Edit/id
        public ActionResult Edit(int id)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = db.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = db.MembershipTypes.ToList()
                };

                return View("New", viewModel);
            }

            if (customer.Id == 0)
            {
                db.Customers.Add(customer);
            }
            else
            {
                var dbCustomer = db.Customers.Single(c => c.Id == customer.Id);

                dbCustomer.FirstName = customer.FirstName;
                dbCustomer.LastName = customer.LastName;
                dbCustomer.Birthdate = customer.Birthdate;
                dbCustomer.MembershipTypeId = customer.MembershipTypeId;
                dbCustomer.IsSybscribedToNewsletter = customer.IsSybscribedToNewsletter;
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

    }
}