using Microsoft.AspNetCore.Mvc;

namespace ItServiceApp.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Register()
		{

			return View();
		}
	}
}
