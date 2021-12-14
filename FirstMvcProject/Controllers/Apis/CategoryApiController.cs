using FirstMvcProject.Models;
using FirstMvcProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
