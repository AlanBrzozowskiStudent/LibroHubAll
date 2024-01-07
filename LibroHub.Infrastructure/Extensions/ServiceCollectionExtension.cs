using LibroHub.Domain.Interfaces;
using LibroHub.Infrastructure.Persistence;
using LibroHub.Infrastructure.Repositories;
using LibroHub.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibroHub.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibroHubDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("LibroHub")));

            //dokumentacja identity
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<LibroHubDbContext>();


            services.AddScoped<LibroHubSeeder>();
            services.AddScoped<ILibroHubRepository, LibroHubRepository>();

        }
    }
}
