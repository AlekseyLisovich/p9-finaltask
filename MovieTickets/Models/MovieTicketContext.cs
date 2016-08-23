using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieTickets.Models
{
    public class MovieTicketContext : DbContext
    {
        public MovieTicketContext()
            : base("DbConnection")
        {
        }

        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
