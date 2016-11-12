using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DbContexts;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyDb db;
        public MoviesController()
        {
            db = new VidlyDb();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // GET: Movies/
        public ActionResult Index()
        {
            var movies = db.Movies.ToList();

            return View(movies);
        }

        // GET: Movies/Details/id
        public ActionResult Details(int id)
        {
            var movie = db.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = db.Genres.ToList()
            };

            return View(viewModel);
        }

        // GET: Movies/Edit/id
        public ActionResult Edit(int id)
        {
            var movie = db.Movies.FirstOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = db.Genres.ToList()
            };

            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = db.Genres.ToList()
                };

                return View("New", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                db.Movies.Add(movie);
            }
            else
            {
                var dbMovie = db.Movies.Single(m => m.Id == movie.Id);
                dbMovie.Title = movie.Title;
                dbMovie.ReleaseDate = movie.ReleaseDate;
                dbMovie.GenreId = movie.GenreId;
                dbMovie.NumberInStock = movie.NumberInStock;
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}