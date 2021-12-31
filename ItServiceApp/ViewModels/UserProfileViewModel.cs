using System.ComponentModel.DataAnnotations;

namespace ItServiceApp.ViewModels
{
    public class UserProfileViewModel
    {
        [Required(ErrorMessage = "isim alanı gereklidir.")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = " Soyisim alanı gereklidir.")]
        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string SurName { get; set; }

        [Required(ErrorMessage = " E-posta alanı gereklidir.")]
        [Display(Name = "E-posta")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
