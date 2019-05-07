using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentAMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Releasedate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public int Stock { get; set; }

        //Refernces
        public Genre Genre { get; set; }

        //reference a column
        [Required]
        public int GenreId { get; set; }

    }
}