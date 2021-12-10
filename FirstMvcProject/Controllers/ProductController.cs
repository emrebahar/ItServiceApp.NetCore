using FirstMvcProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMvcProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly NorthwindContext _northwindContext;
        public ProductController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        public IActionResult Index()
        {
            var data = _northwindContext.Products.Include(x=> x.Category).OrderBy(x => x.ProductName).ToList();
            return View(data);
        }
        public IActionResult Detail(int? id)
        {
            var product = _northwindContext.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("index");
            }
            return View(product);
        }
    }
}
