using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        public String LastName { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        public string PasswordAgain { get; set; }
        public string Phone { get; set; }
    }

    public class LoginUserModel
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    
}