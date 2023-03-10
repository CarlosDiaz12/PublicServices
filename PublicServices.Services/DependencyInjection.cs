using Microsoft.Extensions.DependencyInjection;
using PublicServices.Services.Consult;
using PublicServices.Services.Consult.Interfaces;

namespace PublicServices.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IConsultService, ConsultService>();
            return services;
        }
    }
}
