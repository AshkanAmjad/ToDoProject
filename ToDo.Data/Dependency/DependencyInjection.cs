using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application;
using ToDo.Application.Interfaces;
using ToDo.Data.Context;
using ToDo.Data.Repositores;

namespace ToDo.Data.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
                 this IServiceCollection services,
                 IConfiguration configuration)
        {
            services.AddDbContext<ToDoContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IItemRepository, ItemRepository>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                  cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

            return services;
        }
    }
}
