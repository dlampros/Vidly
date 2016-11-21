using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.App_Start;
using Vidly.DbContexts;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VidlyDb db;

        public CustomersController()
        {
            db = new VidlyDb();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            if (!string.IsNullOrWhiteSpace(query))
                return Ok(db.Customers
                            .Where(c => (c.FirstName + " " + c.LastName).Contains(query))
                            .ToList()
                            .Select(MappingProfile.Mapper.Map<Customer, CustomerDto>));

            return Ok(db.Customers
                        .ToList()
                        .Select(MappingProfile.Mapper.Map<Customer, CustomerDto>));
        }

        // GET /api/customters/id
        public IHttpActionResult GetCustomer(int id)
        {
            var dbCustomer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (dbCustomer == null)
                return NotFound();

            return Ok(MappingProfile.Mapper.Map<Customer, CustomerDto>(dbCustomer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = MappingProfile.Mapper.Map<CustomerDto, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }

        // PUT /api/customers/id
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbCustomer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (dbCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            MappingProfile.Mapper.Map(customerDto, dbCustomer);
            db.SaveChanges();
        }

        // DELETE /api/customers/id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var dbCustomer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (dbCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Customers.Remove(dbCustomer);
            db.SaveChanges();
        }
    }
}
