using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "F.I.O")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parol")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Parol mos kelmadi")]
        [DataType(DataType.Password)]
        [Display(Name = "Parolni takrorlang")]
        public string PasswordConfirm { get; set; }
    }
}
