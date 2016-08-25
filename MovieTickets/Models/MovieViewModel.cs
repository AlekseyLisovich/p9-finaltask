using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<MovieComment> Comment { get; set; }
        public MovieComment NewComment { get; set; }
    }
}