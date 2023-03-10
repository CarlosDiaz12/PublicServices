using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PublicServices.DataAccess.Data;
using PublicServices.DataAccess.Interfaces;
using PublicServices.DataAccess.Repositories;
using PublicServices.DataAccess.Repositories.Base;
using System;

namespace PublicServices.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Main db context
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<AppDbContext>();

            // Generic repository
            services.AddScoped(typeof(IRepository<>), typeof(BaseQueryRepository<>));

            // UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
