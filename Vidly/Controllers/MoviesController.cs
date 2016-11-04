﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }


        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie() { Title = "Shrek" },
                new Movie() { Title = "Wall-e" }
            };
        }
    }
}