using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class Movie
    {
        public Movie()
        {
            this.OrderHistories = new HashSet<OrderHistory>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public Nullable<double> Price { get; set; }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}