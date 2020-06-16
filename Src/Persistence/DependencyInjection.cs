using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PestSchedule.Application.Common.Interfaces;

namespace PetSchedule.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PetScheduleDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PetScheduleDatabase")));

            services.AddScoped<IPetScheduleDbContext>(provider => provider.GetService<PetScheduleDbContext>());

            return services;
        }
    }
}
