using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Apifood.Models
{
    public class Addcustomer
    {
        [Required(ErrorMessage = "Vui lòng nhập Tên")]
        public string customername { get; set; }
        public string customerusername { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Password")]
        public string customerpassword { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email")]
   
        public string customeremail { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập SDT")]
        public string customernumber { get; set; }
        public string customeraddress { get; set; }
       
    }
}
