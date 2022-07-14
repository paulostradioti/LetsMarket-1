using LetsMarket.Models;
using LetsMarket.Views.ViewInterface;

namespace LetsMarket.Controllers.ControllersInterface
{
    public interface IMenuController
    {
        public Menu CreateMenu();
        public void RunMenu(Menu menu, IMenuView menuView);
        public void HandleKey(ConsoleKey key, Menu menu, IMenuView menuView);
    }
}
