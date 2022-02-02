using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItServiceApp.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult SubscriptionTypes()
        {
            return View();
        }
    }
}
