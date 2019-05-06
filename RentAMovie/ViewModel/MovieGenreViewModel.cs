using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentAMovie.ViewModel
{
    public class MovieGenreViewModel
    {
        public Movie Movie { get; set; }

        public List<Genre> Genres { get; set; }

    }
}