using DevExtreme.AspNet.Data;
using ItServiceApp.Extensions;
using ItServiceApp.Models.Identity;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles ="Admin")]
    public class UserApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserApiController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var data = _userManager.Users;
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        [HttpPut]
        public async Task<IActionResult> Update(string key,string values)
        {
            var data = _userManager.Users.FirstOrDefault(x => x.Id == key);
            if (data == null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kullanıcı Bulunamadı"
                });
            }
            JsonConvert.PopulateObject(values, data);
            if (!TryValidateModel(data))
            {
                return BadRequest(ModelState.ToFullErrorString());
            }
            var result = await _userManager.UpdateAsync(data);
            return Ok(new JsonResponseViewModel());
        }
    }
}
