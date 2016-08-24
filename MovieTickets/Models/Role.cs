using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieTickets.Models
{
    public class Role : IdentityRole
    {
        public Role() { }

        public string Description { get; set; }
    }
}