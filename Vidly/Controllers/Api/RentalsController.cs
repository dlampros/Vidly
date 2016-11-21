using System;
using System.Linq;
using System.Web.Http;
using Vidly.App_Start;
using Vidly.DbContexts;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private VidlyDb db;

        public RentalsController()
        {
            db = new VidlyDb();
        }

        // POST /api/rental
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            var customer = db.Customers.Single(c => c.Id == rentalDto.CustomerId);
            var movies = db.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                db.Rentals.Add(rental);
            }
            db.SaveChanges();

            return Ok();
        }
    }
}
