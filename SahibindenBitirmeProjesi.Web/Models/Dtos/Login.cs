using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SahibindenBitirmeProjesi.Web.Models.Dtos
{
    public class Login
    {
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }
        
        public string ReturnUrl { get; set; }
    }
}
