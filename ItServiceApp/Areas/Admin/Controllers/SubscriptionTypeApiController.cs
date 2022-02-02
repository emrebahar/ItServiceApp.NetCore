using DevExtreme.AspNet.Data;
using ItServiceApp.Data;
using ItServiceApp.Extensions;
using ItServiceApp.Models.Entities;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ItServiceApp.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class SubscriptionTypeApiController : Controller
    {
        private readonly MyContext _dbContext;

        public SubscriptionTypeApiController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region Crud
        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var data = _dbContext.SubscriptionTypes
                .Include(x=>x.Subscriptions);
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        [HttpGet]
        public IActionResult Detail(Guid id, DataSourceLoadOptions loadOptions)
        {
            var data = _dbContext.SubscriptionTypes.Where(x => x.Id == id);
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        [HttpPost]
        public IActionResult Insert(string values)
        {
            var data = new SubscriptionType();
            JsonConvert.PopulateObject(values, data);
            if (!TryValidateModel(data))
            {
                return BadRequest(new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = ModelState.ToFullErrorString()
                });
            }
            _dbContext.SubscriptionTypes.Add(data);

            var result = _dbContext.SaveChanges();
            if (result == 0)
            {
                return BadRequest(new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Yeni üyelik tipi kaydedilmedi"
                });
            }
            return Ok(new JsonResponseViewModel());
        }
        [HttpPut]
        public IActionResult Update(Guid key, string values)
        {
            var data = _dbContext.SubscriptionTypes.Find(key);
            if (data == null)
                return BadRequest(new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = ModelState.ToFullErrorString()
                });
            JsonConvert.PopulateObject(values, data);
            if (!TryValidateModel(data))
                return BadRequest(ModelState.ToFullErrorString());

            var result = _dbContext.SaveChanges();
            if (result == 0)
            {
                return BadRequest(new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Üyelik Güncellenemedi"
                });
            }
            return Ok(new JsonResponseViewModel());
        }
        [HttpDelete]
        public IActionResult Delete(Guid key)
        {
            var data = _dbContext.SubscriptionTypes.Find(key);
            if (data == null)
                return StatusCode(StatusCodes.Status409Conflict, "Üyelik tipi bulunamadı");
            _dbContext.SubscriptionTypes.Remove(data);
            var result = _dbContext.SaveChanges();
            if (result == 0)
                return BadRequest("Silme işlemi başarısız");
            return Ok(new JsonResponseViewModel());
        }
        #endregion
    }
}
