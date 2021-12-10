using FirstMvcProject.Models;
using FirstMvcProject.ViewModels;
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
            var data = _northwindContext.Categories.Include(x => x.Products).OrderBy(x => x.CategoryName).ToList();
            return View(data);
        }
        public IActionResult Detail(int id)
        {
            var category = _northwindContext.Categories
                .Include(x => x.Products)
                .ThenInclude(x => x.OrderDetails)
                .ThenInclude(x => x.Order)
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
        public IActionResult Create(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var category = new Category()
            {
                CategoryName = model.CategoryName,
                Description = model.Description
            };
            _northwindContext.Categories.Add(category);
            try
            {
                _northwindContext.SaveChanges();
                return RedirectToAction("Detail", new { id = category.CategoryId });
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"{model.CategoryName} eklenirken bir hata oluştu Tekrar deneyiniz.");
                return View(model);
            }
        }

        public IActionResult Delete(int? id)
        {
            var deleteCategory = _northwindContext.Categories.FirstOrDefault(x => x.CategoryId == id);

            try
            {
                _northwindContext.Categories.Remove(deleteCategory);
                _northwindContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return RedirectToAction("Detail", new { id = id });
            }
            TempData["Silinen Kategori"] = deleteCategory.CategoryName;
            return RedirectToAction("Index");

        }
        public IActionResult Update(int id)
        {

            var updateCategory = _northwindContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (updateCategory == null)
            {
                return RedirectToAction("Index");
            }
            var model = new CategoryViewModel()
            {
                CategoryID = updateCategory.CategoryId,
                CategoryName = updateCategory.CategoryName,
                Description = updateCategory.Description
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var updateCategory = _northwindContext.Categories.FirstOrDefault(x => x.CategoryId == model.CategoryID);

            try
            {
                updateCategory.CategoryName = model.CategoryName;
                updateCategory.Description = model.Description;
                _northwindContext.Update(updateCategory);
                _northwindContext.SaveChanges();
                return RedirectToAction("Detail", new { id = updateCategory.CategoryId });
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, $"{model.CategoryName } Güncellenirken bir hata oluştu. Tekrar deneyiniz");
            }
            return View(model);
        }
    }
}
