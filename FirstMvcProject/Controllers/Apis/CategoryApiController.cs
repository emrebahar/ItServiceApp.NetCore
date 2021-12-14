using FirstMvcProject.Models;
using FirstMvcProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMvcProject.Controllers.Apis
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;
        public CategoryApiController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = _northwindContext.Categories
                    .Include(x => x.Products)
                    .OrderBy(x => x.CategoryName)
                    .Select(x => new CategoryViewModel
                    {
                        CategoryId = x.CategoryId,
                        CategoryName = x.CategoryName,
                        Description = x.Description,
                        ProductCount = x.Products.Count
                    })
                    .ToList();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           var category =new Category()
            {
                CategoryName = model.CategoryName,
                Description = model.Description
            };
            try
            {
                _northwindContext.Categories.Add(category);
                _northwindContext.SaveChanges();
                return Ok(new
                {
                    Message = "Kategori ekleme işlemi başarılı",
                    Model = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("~/api/CategoryApi/UpdateCategory/{id?}")] //Custom Route 
        public IActionResult UpdateCategory(int? id, CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var category = _northwindContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound("Kategori Bulunamadı.");
            }
            category.CategoryName = model.CategoryName;
            category.Description = model.Description;
            try
            {
                _northwindContext.Categories.Update(category);
                _northwindContext.SaveChanges();
                return Ok(new
                {
                    Message = "Kategori güncelleme işlemi başarılı",
                    Model = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult DeleteCategory(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var deleteCategory = _northwindContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            try
            {
                _northwindContext.Categories.Remove(deleteCategory);
                _northwindContext.SaveChanges();
                return Ok(new
                {
                    Message = "Kategori silme işlemi başarılı",
                    Model = deleteCategory
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
