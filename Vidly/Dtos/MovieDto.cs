using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie's title.")]
        [StringLength(120, ErrorMessage = "Title can't be bigger than 50 characters.")]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please enter movie's released date in the fromat dd MMM yyyy.")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please enter movie's date added in the fromat dd MMM yyyy.")]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Please enter number of movies in stock.")]
        public short NumberInStock { get; set; }

        [Required(ErrorMessage = "Please select movie's genre.")]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}