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
        [Required]
        [StringLength(120)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
        [Required]
        [Display(Name = "Number In Stock")]
        public short NumberInStock { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}