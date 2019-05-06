using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RentAMovie.ViewModel;

namespace RentAMovie.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movie = dbContext.Movies.Include(c => c.Genre).ToList();
            return View(movie);
        }

       public ActionResult Details(int id)
        {
            var movie = dbContext.Movies.Include(c => c.Genre).SingleOrDefault(x => x.ID == id);
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

        [HttpGet]
        public ActionResult Create()
        {
            MovieGenreViewModel viewModel = new MovieGenreViewModel();
            Movie movie = new Movie();
            var genreTypes = dbContext.Genres.ToList();
            viewModel.Movie = movie;
            viewModel.Genres = genreTypes;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(c => c.ID == id);
            var genreTypes = dbContext.Genres.ToList();
            MovieGenreViewModel viewModel = new MovieGenreViewModel
            {
                Movie = movie,
                Genres = genreTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            var movietbl = dbContext.Movies.SingleOrDefault(c => c.ID == movie.ID);
            if (movietbl == null)
            {
                return HttpNotFound();
            }
            else
            {
                movietbl.Name = movie.Name;
                movietbl.Releasedate = movie.Releasedate;
                movietbl.DateAdded = movie.DateAdded;
                movietbl.Stock = movie.Stock;
                movietbl.GenreId = movie.GenreId;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Movies");
        }
    }
}