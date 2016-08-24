using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieTickets.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.OrderHistories = new HashSet<OrderHistory>();
        }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}