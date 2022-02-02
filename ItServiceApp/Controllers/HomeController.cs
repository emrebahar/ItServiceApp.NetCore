using ItServiceApp.Data;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ItServiceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _dbContext;

        public HomeController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<PricingTableViewModel> pricingTableViewModels = new List<PricingTableViewModel>();
            var data = _dbContext.SubscriptionTypes.ToList();
            foreach (var item in data)
            {
                pricingTableViewModels.Add(new PricingTableViewModel
                {
                    Name = item.Name,
                    Price = item.Price,
                    Description = item.Description,
                    Month = item.Month
                });
            }
            return View(pricingTableViewModels);
        }
    }
}
