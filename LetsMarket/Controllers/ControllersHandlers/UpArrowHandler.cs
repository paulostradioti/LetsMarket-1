using LetsMarket.Models;

namespace LetsMarket.Controllers.ControllersHandlers
{
    public class UpArrowHandler : IKeyHandler
    {
        private List<ConsoleKey> associatedKeys = new List<ConsoleKey>()
            {
                ConsoleKey.UpArrow,
                ConsoleKey.PageUp,
            };

        public List<ConsoleKey> GetAssociatedKeys() => associatedKeys;

        public Menu HandleKey(Menu menu)
        {
            menu.selectedIndex = Math.Max(menu.selectedIndex - 1, 0);
            return menu;
        }
    }
}