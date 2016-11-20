using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter movie's title.")]
        [StringLength(120, ErrorMessage = "Title can't be bigger than 50 characters.")]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please enter movie's released date in the fromat dd MMM yyyy.")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required(ErrorMessage = "Please enter number of movies in stock.")]
        public byte? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please select movie's genre.")]
        public byte? GenreId { get; set; }

        public MovieFormViewModel() { }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}