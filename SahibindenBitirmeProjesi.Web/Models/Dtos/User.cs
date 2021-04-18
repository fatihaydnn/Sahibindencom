using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SahibindenBitirmeProjesi.Web.Models.Dtos
{
    public class User
    {
        [Required(ErrorMessage ="Kullanıcı Adını giriniz..!")]
        [Display(Name ="Kullanıcı Adı")]
        [MinLength(3,ErrorMessage ="Minimum 3 karakter içermelidir..!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifreyinizi giriniz..!")]
        [Display(Name ="Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "E mail bilginizi giriniz..!")]
        [DataType(DataType.EmailAddress, ErrorMessage ="E mail adresinizi kontrol ediniz..! ")]
        [Display(Name ="E Mail")]
        [MinLength(3, ErrorMessage = "Minimum 3 karakter içermelidir..!")]
        public string Email { get; set; }
    }
}
