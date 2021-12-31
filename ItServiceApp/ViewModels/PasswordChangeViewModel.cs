using System.ComponentModel.DataAnnotations;

namespace ItServiceApp.ViewModels
{
    public class PasswordChangeViewModel
    {
        [Required(ErrorMessage = "Eski Şifre Alanı gereklidir.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz min 6 karakter olmalıdır.")]
        [Display(Name = "Eski Şifre")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
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
