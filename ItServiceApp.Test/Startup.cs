using ItServiceApp.MapperProfiles;
using ItServiceApp.Services;
using Microsoft.Extensions.DependencyInjection;
namespace ItServiceApp.Test
{
    public class Startup
    {
        protected void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPaymentService, IyzicoPaymentService>();
            services.AddAutoMapper(options =>
            {
                options.AddProfile(typeof(PaymentProfile));
            });
        }
    }
}
