using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("defaultConnection"),
                    b => b.MigrationsAssembly(typeof(LibraryContext).Assembly.FullName)));
            return services;
        }
    }
}
