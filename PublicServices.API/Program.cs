using Microsoft.Extensions.Options;
using PublicServices.DataAccess;
using PublicServices.DataAccess.Data;
using PublicServices.DataAccess.Interfaces;
using PublicServices.DataAccess.Repositories;
using PublicServices.Services;
namespace PublicServices.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplicationServices();
            builder.Services.AddDataAccessServices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
                app.UseSwagger();

            if(app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI();
            } else
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Public Services API V1");
                    options.RoutePrefix = string.Empty;
                });
            }

            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}