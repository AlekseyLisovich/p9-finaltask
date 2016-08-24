using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class OrderHistory
    {
        public OrderHistory()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int ID { get; set; }
        public int StatusID { get; set; }
        public string UserId { get; set; }
        public System.DateTime Date { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}