using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeknikServisCore.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required, MinLength(2, ErrorMessage = "Kullanıcı adınız 2 karakterden fazla olmalıdır."), MaxLength(25, ErrorMessage = "Kullanıcı adınız 25 karakterden az olamaz."), DisplayName("Soyisim")]
        public string UserName { get; set; }
        [Required, MaxLength(25, ErrorMessage = "Şifreniz en fazla 25 karakter olabilir"), DisplayName("Şifre")]
        public string Password { get; set; }
    }
}
