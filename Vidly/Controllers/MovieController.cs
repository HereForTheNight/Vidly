using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Migrations;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private MyDBContext _context;

        public MovieController()
        {
            _context = new MyDBContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
        
            return View(viewModel);

        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();


            var viewModel = new MovieFormViewModel(movie)
            {
                MovieGenres = _context.MovieGenre.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ViewResult New()
        {
            var genres = _context.MovieGenre.ToList();

            var viewModel = new MovieFormViewModel
            {
                MovieGenres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    MovieGenres = _context.MovieGenre.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.MovieGenreId = movie.MovieGenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}