using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentAMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Releasedate { get; set; }
        public DateTime DateAdded { get; set; }

        //Refernces
        public Genre Genre { get; set; }

        //reference a column
        public int GenreId { get; set; }

    }
}