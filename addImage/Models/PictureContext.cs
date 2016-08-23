using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace addImage.Models
{
    public class PictureContext : DbContext
    {
        public PictureContext()
            : base("DefaultConnection")
        { }

        public DbSet<Picture> Pictures { get; set; }
    }
}