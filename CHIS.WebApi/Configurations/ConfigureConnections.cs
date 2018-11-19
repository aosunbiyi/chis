using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CHIS.Core.Domain;
namespace CHIS.WebApi.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration) =>
    services.AddDbContext<hotel_dbContext>(options => options
        .UseMySQL(configuration.GetConnectionString("DefaultConnection")));
    }
}
