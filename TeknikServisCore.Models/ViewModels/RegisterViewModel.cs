using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeknikServisCore.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required,MinLength(2,ErrorMessage ="İsminiz 2 karakterden fazla olmalıdır."),MaxLength(15,ErrorMessage = "İsminiz 15 karakterden az olamaz."),DisplayName("Kullanıcı Adı")]
        public string Name { get; set; }
        [Required, MinLength(2, ErrorMessage = "Soyadınız 2 karakterden fazla olmalıdır."), MaxLength(25, ErrorMessage = "Soyadınız 25 karakterden az olamaz."), DisplayName("İsim")]
        public string Surname { get; set; }
        [Required, MinLength(2, ErrorMessage = "Kullanıcı adınız 2 karakterden fazla olmalıdır."), MaxLength(25, ErrorMessage = "Kullanıcı adınız 25 karakterden az olamaz."), DisplayName("Soyisim")]
        public string UserName { get; set; }
        [Required, DisplayName("Doğum Tarihi")]
        public DateTime BirthDate { get; set; }
        [Required, MaxLength(25,ErrorMessage ="Şifreniz en fazla 25 karakter olabilir"),DisplayName("Şifre")]
        public string Password { get; set; }
        [Required, MaxLength(25, ErrorMessage = "Şifreniz en fazla 25 karakter olabilir"),DisplayName("Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
        [Required, MaxLength(100,ErrorMessage ="ADresiniz en fazla 100 karakter olabilir."),DisplayName("Adres")]
        public string Address { get; set; }
    }
}
