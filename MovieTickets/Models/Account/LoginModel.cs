using System;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}