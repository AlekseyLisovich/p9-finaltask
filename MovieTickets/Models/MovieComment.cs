using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class MovieComment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTime PublishDate { get; set; }
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}