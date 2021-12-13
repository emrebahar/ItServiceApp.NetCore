using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMvcProject.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public string CompanyName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Range(0, 9999999999,ErrorMessage = "Ürün Fiyatı 0-9999999999 arasında olmalıdır.")]
        public decimal? UnitPrice { get; set; }
    }
}
