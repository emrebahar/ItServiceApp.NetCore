using System.ComponentModel.DataAnnotations;

namespace ItServiceApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = " Kullanıcı Adı alanı gereklidir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = " Şifre alanı gereklidir.")]
        [Display(Name = "Şifre")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz Min 6 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
