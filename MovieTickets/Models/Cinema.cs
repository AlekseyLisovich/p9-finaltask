using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Sessions { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public Cinema()
        {
            Movies = new List<Movie>();
        }
    }
}