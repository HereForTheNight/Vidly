using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {

        private MyDBContext _context;

        public NewRentalsController()
        {
            _context = new MyDBContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movies have been selected.");

            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == newRental.CustomerId);

            if(customer == null)
            {
                return BadRequest("Customer is not valid.");
            }

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or movies are invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie ID '{0}' is not in stock" + movie.Id);

                movie.NumberAvailable--;

                var rental = new Rental()
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