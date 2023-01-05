using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ tên")]
        [RegularExpression(@"^[a-zA-Z][\sa-zA-Z]*", ErrorMessage = "Kí tự đặc biệt không được cho phép.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng định dạng Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Description { get; set; }
    }
}
