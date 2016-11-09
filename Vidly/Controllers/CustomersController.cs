using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DbContexts;
using Vidly.Models;

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
        [Route("Customers/Details/{id:int:min(1)}")]
        public ActionResult Details(int id)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}