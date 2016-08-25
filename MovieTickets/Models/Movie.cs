using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Movie
    {
        public Movie()
        {
            this.OrderHistories = new HashSet<OrderHistory>();
            this.MovieComments = new HashSet<MovieComment>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public double? Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double Rating { get; set; }

        public virtual ICollection<MovieComment> MovieComments { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}