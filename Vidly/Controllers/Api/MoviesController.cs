using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.App_Start;
using Vidly.DbContexts;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private VidlyDb db;

        public MoviesController()
        {
            db = new VidlyDb();
        }

        // GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = db.Movies
                                .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                return Ok(moviesQuery.Where(m => m.Title.Contains(query))
                                    .ToList()
                                    .Select(MappingProfile.Mapper.Map<Movie, MovieDto>));

            return Ok(moviesQuery.ToList()
                                .Select(MappingProfile.Mapper.Map<Movie, MovieDto>));
        }

        // GET /api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = db.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(MappingProfile.Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbMovie = MappingProfile.Mapper.Map<MovieDto, Movie>(movieDto);
            db.Movies.Add(dbMovie);
            db.SaveChanges();

            movieDto.Id = dbMovie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        // PUT /api/movie/id
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbMovie = db.Movies.SingleOrDefault(m => m.Id == id);
            if (dbMovie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            MappingProfile.Mapper.Map(movieDto, dbMovie);
            db.SaveChanges();
        }

        // DELETE /api/movies/id
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var dbMovie = db.Movies.SingleOrDefault(m => m.Id == id);
            if (dbMovie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Movies.Remove(dbMovie);
            db.SaveChanges();
        }
    }
}
