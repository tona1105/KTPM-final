using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CakeShop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ tên")]
        [RegularExpression(@"^[a-zA-Z][\sa-zA-Z]*", ErrorMessage = "Kí tự đặc biệt không được cho phép.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [RegularExpression(@"^([A-Za-z0-9\s]*$)", ErrorMessage = "Kí tự đặc biệt không được cho phép.")]
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "Độ dài tài khoản chứa 6 - 50 kí tự")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Password")]
        [StringLength(maximumLength: 25, MinimumLength = 6, ErrorMessage = "Mật khẩu phải chứa 6 kí tự trở lên")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng định dạng Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập SDT")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Chỉ cho phép kí tự số")]
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "Độ dài SĐT chứa 6 - 50 kí tự")]
        public string Phone { get; set; }

    }
}