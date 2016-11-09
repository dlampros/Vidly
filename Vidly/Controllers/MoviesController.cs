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
        [Route("Movies/Details/{id:int:min(1)}")]
        public ActionResult Details(int id)
        {
            var movie = db.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}