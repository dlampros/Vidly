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

        // GET /api/rental/id
        //public IHttpActionResult Action(int Id)
        //{
        //    var rentals = db.Rentals.Where(r=>r.Id)

        //    return;
        //}

        // POST /api/rental
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Rentals.Add(MappingProfile.Mapper.Map<RentalDto, Rental>(rentalDto));
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + rentalDto.CustomerId), rentalDto);
        }
    }
}
