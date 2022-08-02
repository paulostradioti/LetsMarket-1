using System.Data;
using System.Reflection;
using LetsMarket.Controllers;
using LetsMarket.Controllers.ControllersHandlers;
using LetsMarket.Controllers.ControllersInterface;
using LetsMarket.Controllers.Interfaces;
using LetsMarket.Repositories;
using LetsMarket.Repositories.Interfaces;
using LetsMarket.Views;
using LetsMarket.Views.Interfaces;
using LetsMarket.Views.ViewInterface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static LetsMarket.Utils;

namespace LetsMarket
{
    public class Program
    {
        static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();

            var serviceCollection = new ServiceCollection()
                .AddScoped<IMenuView, MenuView>()
                .AddScoped<ILoginView, LoginView>()
                .AddScoped<IEmployeeView, EmployeeView>()
                .AddScoped<IProductView, ProductView>()
                .AddScoped<ILoginController, LoginController>()
                .AddScoped<IMenuController, MenuController>()
                .AddScoped<IEmployeeController, EmployeeController>()
                .AddScoped<IProductController, ProductController>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IKeyHandlerFactory, KeyHandlerFactory>()
                .AddSingleton<IConfigurationRoot>(configuration)
                .AddTransient<CartController>()
                .AddRepository();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var loginController = serviceProvider.GetService<ILoginController>();
            var menuController = serviceProvider.GetService<IMenuController>();

            ConfigurePrompt();
            var employee = loginController.Login();

            var mainMenu = menuController.CreateMenu();
            menuController.RunMenu(mainMenu);
        }
    }
}