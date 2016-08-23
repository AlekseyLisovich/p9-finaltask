using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class OrderStatus
    {
        public OrderStatus()
        {
            this.OrderHistories = new HashSet<OrderHistory>();
        }

        public int ID { get; set; }
        public bool Name { get; set; }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}