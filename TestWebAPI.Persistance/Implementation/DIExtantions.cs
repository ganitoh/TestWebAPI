using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestWebAPI.Persistance.Implementation
{
    public static class DIExtantions
    {
        public static IServiceCollection AddSQLiteRepository( 
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connectionString));
            return services;
        }
    }
}
