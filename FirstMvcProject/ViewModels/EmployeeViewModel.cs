using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMvcProject.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Ad Alanı Gereklidir."), StringLength(10, ErrorMessage = "Ad Alanı En Fazla 15 Karakter olabilir!")]
        [Display(Name = "Çalışan Ad")]
        public string FirsName { get; set; }
        [Required(ErrorMessage = "Soyad Alanı Gereklidir."), StringLength(20, ErrorMessage = "Soy ad Alanı En Fazla 15 Karakter olabilir!")]
        [Display(Name = "Çalışan Soyad")]
        public string LastName { get; set; }
        [Display(Name = "Ünvan")]
        public string Title { get; set; }
        [Display(Name = "Şehir")]
        public string City { get; set; }
        [Display(Name = "Doğum Günü")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Adres")]
        public string Adress { get; set; }

    }
}
