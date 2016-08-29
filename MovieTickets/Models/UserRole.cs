using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class UserRole
    {
        public User User { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}