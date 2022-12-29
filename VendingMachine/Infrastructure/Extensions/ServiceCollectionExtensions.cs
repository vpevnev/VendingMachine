using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMachine(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWalletService, WalletService>();
            services.AddSingleton<IMenuService, MenuService>();

            services.Configure<Machine>(configuration.GetSection("Machine"));

            return services;
        }
    }
}
