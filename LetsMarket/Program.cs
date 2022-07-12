using LetsMarket.Controllers;
using LetsMarket.Controllers.ControllersInterface;
using LetsMarket.Views;
using LetsMarket.Views.ViewInterface;
using Microsoft.Extensions.DependencyInjection;
using static LetsMarket.Utils;

namespace LetsMarket
{
    public class Program
    {     
        static void Main()
        {
            var serviceCollection = new ServiceCollection()
                .AddScoped<ILoginController, LoginController>()
                .AddScoped<ILoginView, LoginView>()
                .AddScoped<IMenuController, MenuController>()
                .AddScoped<IMenuView, MenuView>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var loginView = serviceProvider.GetService<ILoginView>();
            var loginController = serviceProvider.GetService<ILoginController>();
            var menuController = serviceProvider.GetService<IMenuController>();
            var menuView = serviceProvider.GetService<IMenuView>();

            ConfigurePrompt();
            var employee = loginController.Login(loginView);

            var mainMenu = menuController.CreateMenu();
            menuController.RunMenu(mainMenu, menuView);
        }
    }
}