using FirstMvcProject.Models;
using FirstMvcProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMvcProject.Controllers.Apis
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly NorthwindContext _dbContext;
        public ProductApiController(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            var newProduct = new Product()
            {
                CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice
            };
            try
            {
                _dbContext.Products.Add(newProduct);
                _dbContext.SaveChanges();
                return Ok(new
                {
                    Message = "Ürün Ekleme İşlemi Başarılı",
                    Model = newProduct
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir Hata Oluştu : {ex.Message}");
            }
        }
        [HttpPost]
        [Route("~/api/ProductApi/Delete/{id?}")]
        public IActionResult Delete(int id = 0)
        {
            var deleteProduct = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
            if (deleteProduct == null)
            {
                return NotFound("Ürün Bulunamadı");
            }
            
            try
            {
                _dbContext.Products.Remove(deleteProduct);
                _dbContext.SaveChanges();
                return Ok(new
                {
                    Message = $"{deleteProduct.ProductName} isimli Ürün Başarıyla silindi.",
                    Model = deleteProduct
                });
            }
            catch (Exception ex)
            {

                return BadRequest($"Bir hata Oluştu: {ex.Message}");
            }
        }
    }
}
