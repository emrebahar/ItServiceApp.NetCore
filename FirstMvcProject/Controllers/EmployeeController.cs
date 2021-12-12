using FirstMvcProject.Models;
using FirstMvcProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMvcProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly NorthwindContext _northwindContext;
        public EmployeeController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        public IActionResult Index()
        {
            var data = _northwindContext.Employees.OrderBy(x => x.EmployeeId).ToList();
            return View(data);
        }
        public IActionResult Detail(int id)
        {
            var employee = _northwindContext.Employees
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.EmployeeId == id);
            return View(employee);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Employee employee = new Employee
            {
                FirstName = model.FirsName,
                LastName = model.LastName,
                Title = model.Title,
                City = model.City,
                Address = model.Adress,
                BirthDate = model.BirthDate
            };
            _northwindContext.Employees.Add(employee);
            try
            {
                _northwindContext.SaveChanges();
                return RedirectToAction("Detail", new { id = employee.EmployeeId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, $"{model.FirsName + model.LastName} eklenirken bir hata oluştu Tekrar deneyiniz.");
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            var deleteEmploye = _northwindContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            try
            {
                _northwindContext.Employees.Remove(deleteEmploye);
                _northwindContext.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Detail", new { id = id });
            }
            TempData["Silinen Çalışan"] = deleteEmploye.FirstName + " " + deleteEmploye.LastName;
            return RedirectToAction("Index");
        }
    }
}
