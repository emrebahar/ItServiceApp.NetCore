using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string Code { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "Yeni Şifre Alanı gereklidir.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz min 6 karakter olmalıdır.")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = " Şifre tekrar alanı gereklidir.")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]

        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
        
    }
}
