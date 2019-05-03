using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentAMovie.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movie = GetMovies();
            return View(movie);
        }

       public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(x => x.ID == id);
            return View(movie);
        }
        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie{ID = 1,Name = "Jersey",Releasedate = Convert.ToDateTime("20/04/2019"),DateAdded=DateTime.Now},
                new Movie{ID = 2,Name = "Nenu Local",Releasedate = Convert.ToDateTime("20/04/2018"),DateAdded=DateTime.Now}
            };
            return movies;
        }
    }
}