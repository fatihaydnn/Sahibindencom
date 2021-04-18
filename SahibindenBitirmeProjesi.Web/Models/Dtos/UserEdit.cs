using SahibindenBitirmeProjesi.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SahibindenBitirmeProjesi.Web.Models.Dtos
{
    public class UserEdit
    {
        [Required(ErrorMessage ="Kullanıcı adını giriniz..!")]
        [Display(Name ="Kullanıcı Adı")]
        [MinLength(3,ErrorMessage ="Minimum 3 karakter olmalıdır..!")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Şifreyi giriniz..!")]
        [DataType(DataType.Password)]
        [Display(Name ="Şifre")]
        public string Password { get; set; }

        public UserEdit() { }

        public UserEdit(AppUser appUser)
        {
            UserName = appUser.UserName;
            Password = appUser.PasswordHash;
        }
    }
}
