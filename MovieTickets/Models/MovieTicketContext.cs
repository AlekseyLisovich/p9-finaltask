using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieTickets.Models
{
    public class MovieTicketContext : IdentityDbContext<User>
    {
        public MovieTicketContext()
            : base("DbConnection")
        {
        }
        public static MovieTicketContext Create()
        {
            return new MovieTicketContext();
        }

        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
    }
}
