using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter movie's title.")]
        [StringLength(120, ErrorMessage = "Title can't be bigger than 50 characters.")]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please enter movie's released date in the fromat dd MMM yyyy.")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        [Required(ErrorMessage = "Please enter movie's date added in the fromat dd MMM yyyy.")]
        public DateTime AddedDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required(ErrorMessage = "Please enter number of movies in stock.")]
        public short NumberInStock { get; set; }


        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please select movie's genre.")]
        public byte GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}