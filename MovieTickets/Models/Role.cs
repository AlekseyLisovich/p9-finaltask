using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public int ID { get; set; }
        public string RoleStatus { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}