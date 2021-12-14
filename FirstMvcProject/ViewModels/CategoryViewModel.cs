using FirstMvcProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMvcProject.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Kategori Alanı Gereklidir."),StringLength(15,ErrorMessage ="Ad Alanı En Fazla 15 Karakter olabilir!")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public int ProductCount { get; set; }
    }
}
