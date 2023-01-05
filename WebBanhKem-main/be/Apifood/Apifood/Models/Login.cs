using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CakeShop.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Vui lòng nhập Tên")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Password")]
        public string Password { get; set; }
    }
}