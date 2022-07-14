using LetsMarket.Controllers.ControllersHandlers;
using LetsMarket.Models;
using LetsMarket.Views.ViewInterface;

namespace LetsMarket.Controllers.ControllersInterface
{
    public interface IMenuController
    {
        public Menu CreateMenu();
        public void RunMenu(Menu menu);
    }
}
