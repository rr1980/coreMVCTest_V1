using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; } = "rr1980";
        [DataType(DataType.Password)]
        public string Password { get; set; } = "12003";
        [Required]
        public string ReturnUrl { get; set; }
    }
}
