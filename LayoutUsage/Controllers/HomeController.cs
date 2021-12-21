using LayoutUsage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutUsage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Karpuz",
                    UnitPrice = 7
                },
                new Product()
                {
                    Id = 2,
                    Name = "Erik",
                    UnitPrice = 9
                }
            };
            return View(model);
        }
    }
}
