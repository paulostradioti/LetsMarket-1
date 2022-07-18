using LetsMarket.Models;

namespace LetsMarket.Controllers.ControllersHandlers
{
    public class EnterHandler : IKeyHandler
    {
        private List<ConsoleKey> associatedKeys = new List<ConsoleKey>()
            {
                ConsoleKey.Enter,
                ConsoleKey.RightArrow,
            };

        public Menu HandleKey(Menu menu)
        {
            return menu.items[menu.selectedIndex];
        }

        public List<ConsoleKey> GetAssociatedKeys() => associatedKeys;
    }
}
