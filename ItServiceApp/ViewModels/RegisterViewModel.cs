using System.ComponentModel.DataAnnotations;

namespace ItServiceApp.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = " Kullanıcı Adı alanı gereklidir.")]
		[Display(Name = "Kullanıcı Adı")]
		public string UserName { get; set; }
		[Required(ErrorMessage ="isim alanı gereklidir.")]
		[Display(Name ="Ad")]
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
		[Required(ErrorMessage = " Şifre alanı gereklidir.")]
		[Display(Name = "Şifre")]
		[StringLength(100,MinimumLength =6,ErrorMessage ="Şifreniz Min 6 karakter olmalıdır.")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = " Şifre tekrar alanı gereklidir.")]
		[Display(Name = "Şifre Tekrar")]
		[DataType(DataType.Password)]

		[Compare(nameof(Password),ErrorMessage ="Şifreler Uyuşmuyor!")]
		public string ConfirmPassword { get; set; }
	}
}
