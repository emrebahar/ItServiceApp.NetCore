using AutoMapper;
using ItServiceApp.Data;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ItServiceApp.Components
{
    public class PricingTableViewComponent : ViewComponent
    {
        private readonly MyContext _dbContext;
        private readonly IMapper _mapper;

        public PricingTableViewComponent(MyContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var model = _dbContext.SubscriptionTypes
                .OrderBy(x => x.Price)
                .ToList()
                .Select(x => _mapper.Map<SubscriptionTypeViewModel>(x))
                .ToList();
            return View(model);
        }


    }
}
