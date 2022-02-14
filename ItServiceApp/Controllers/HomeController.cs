using AutoMapper;
using ItServiceApp.Data;
using ItServiceApp.Models.Identity;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ItServiceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(MyContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            foreach (var item in _userManager.Users.ToList())
            {
                var v1 = _userManager.RemovePasswordAsync(item).Result;
                var v2 = _userManager.AddPasswordAsync(item, "Emre12345*").Result;
            }
            return View();
        }
    }
}
