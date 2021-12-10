using FirstMvcProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FirstMvcProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NorthwindContext _northwindContext;
        public CategoryController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        public IActionResult Index()
        {
            var data = _northwindContext.Categories.Include(x=>x.Products).OrderBy(x=> x.CategoryName).ToList();
            return View(data);
        }
        public IActionResult Detail(int id)
        {
            var category = _northwindContext.Categories
                .Include(x=> x.Products)
                .ThenInclude(x=> x.OrderDetails)
                .ThenInclude(x=>x.Order)
                .FirstOrDefault(x => x.CategoryId == id);

            //********* 2. YOL *********
            //var category2 = from cat in _northwindContext.Categories
            //                join prod in _northwindContext.Products on cat.CategoryId equals prod.CategoryId
            //                join odetail in _northwindContext.OrderDetails on prod.ProductId equals odetail.ProductId
            //                join ord in _northwindContext.Orders on odetail.OrderId equals ord.OrderId
            //                where category.CategoryId == id
            //                select cat;
            //var model = category2.FirstOrDefault();    //

            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {

            return View();
        }
    }
}
