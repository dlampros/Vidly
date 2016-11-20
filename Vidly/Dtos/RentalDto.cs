using System.Collections.Generic;

namespace Vidly.Dtos
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MoviesId { get; set; }
    }
}