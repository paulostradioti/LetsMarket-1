using LetsMarket.Models;

namespace LetsMarket.Controllers.ControllersHandlers
{
    public class DownArrowHandler : IKeyHandler
    {
        private List<ConsoleKey> associatedKeys = new List<ConsoleKey>()
            {
                ConsoleKey.DownArrow,
                ConsoleKey.PageDown,
            };

        public Menu HandleKey(Menu menu)
        {
            menu.selectedIndex = Math.Min(menu.selectedIndex + 1, Math.Max(menu.items.Count - 1, 0));
            return menu;
        }

        public List<ConsoleKey> GetAssociatedKeys() => associatedKeys;
    }
}
