using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models.Account
{
    public class EditModel
    {
        [Display(Name = "Ваше имя")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}