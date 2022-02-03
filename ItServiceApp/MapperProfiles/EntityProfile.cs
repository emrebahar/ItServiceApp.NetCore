using AutoMapper;
using ItServiceApp.Models.Entities;
using ItServiceApp.ViewModels;

namespace ItServiceApp.MapperProfiles
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<SubscriptionType,SubscriptionTypeViewModel>().ReverseMap();
        }
    }
}
