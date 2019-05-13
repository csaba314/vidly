using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            // movies table is rendered by DataTable using the api so no longer needed to provide a list
            // var movies = _context.Movies.Include(m => m.Genre).ToList();
            //return View(movies);


            // check if the user is on a role
            if (User.IsInRole("CanManageMovies"))
            {   // if user is in "CanEditMovies" role send him to the List with edit permissions
                return View("List");
            }

            // if user is not in "CanEditMovies" role send him to the read only list
            return View("ReadOnlyList");

        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // add a authorize attribute to limit the usage of New() action to certain roles
        // this will override the global autorize filter
        [Authorize(Roles = "CanManageMovies")]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                return View("MovieForm",
                    new MovieFormViewModel(movie)
                    {
                        Genres = _context.Genres.ToList()
                    });
            }


            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }


            _context.SaveChanges();



            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

    }
}