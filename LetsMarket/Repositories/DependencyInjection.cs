using LetsMarket.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LetsMarket.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;

        }
    }
}
