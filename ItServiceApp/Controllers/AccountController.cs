using ItServiceApp.Models.Identity;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ItServiceApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
        }
		[HttpGet]
		public IActionResult Register()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
				return View(model);
            }

			var user = await _userManager.FindByNameAsync(model.UserName);
            if (user !=null)
            {
				ModelState.AddModelError(nameof(model.UserName),"Bu kullanıcı adı daha önce kayıt edilmiştir!");
				return View(model);
            }

			user = await _userManager.FindByEmailAsync(model.Email);
			if (user != null)
            {
				ModelState.AddModelError(nameof(model.Email), "Bu Email adresi daha önce kayıt edilmiştir!");
				return View(model);
			}

			user = new ApplicationUser 
			{
				UserName = model.UserName,
				Email = model.Email,
				Name = model.Name,
				SurName = model.SurName
			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded) 
			{
				//Kullanıcıya rol atama, Email onay Maili, Login Sayfasına Yönlendirme
				return RedirectToAction("Index", "Home");
			}
            else
            {
				ModelState.AddModelError(string.Empty, "Bir Hata Oluştu");
            }

			return View();
        }

		[HttpGet]
		public IActionResult Login()
        {
			return View();
        }
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
				return View(model);
            }
			var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe,true);
            if (result.Succeeded)
            {
				return RedirectToAction("Index", "Home");
            }
            else
            {
				ModelState.AddModelError(string.Empty, "Kullanıcı Adı veya Şifre Hatalı!");
				return View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
        }
	}
}
