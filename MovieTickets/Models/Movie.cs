using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Movie
    {
        public Movie()
        {
            this.OrderHistories = new HashSet<OrderHistory>();
            this.MovieComments = new HashSet<MovieComment>();
        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Description { get; set; }
   
        public byte[] Image { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public double? Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double Rating { get; set; }

        public virtual ICollection<MovieComment> MovieComments { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}