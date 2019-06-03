using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            // check if there are movie ids present
            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Ids have been given");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            // check if customerId is valid
            if (customer == null)
            {
                return BadRequest("CustomerId is not valid");
            }

            var movies = new List<Movie>();

            foreach (int movieId in newRental.MovieIds)
            {
                if (_context.Movies.FirstOrDefault(m => m.Id == movieId) != null)
                {
                    movies.Add(_context.Movies.First(m => m.Id == movieId));
                }
            }

            // check if one or more movie ids are invalid
            if (movies.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or more MovieIds are invalid");
            }

            foreach (var movie in movies)
            {
                // check if the movie is available
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();

            return Ok();
        }

    }
}
