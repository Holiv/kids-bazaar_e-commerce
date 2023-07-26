using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidsBazaar.Extensions
{
    public static class AddApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });


            return services;
        }
    }
}
