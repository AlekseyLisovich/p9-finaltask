using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class MovieCinema
    {
        public Cinema Cinema { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}