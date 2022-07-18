using LetsMarket.Models;

namespace LetsMarket.Controllers.ControllersHandlers
{
    public class EscapeHandler : IKeyHandler
    {
        private List<ConsoleKey> associatedKeys = new List<ConsoleKey>()
            {
                ConsoleKey.Escape,
                ConsoleKey.Backspace,
                ConsoleKey.LeftArrow,
            };

        public Menu HandleKey(Menu menu)
        {
            if (menu.parent != null)
                return menu.parent;

            return menu;
        }

        public List<ConsoleKey> GetAssociatedKeys() => associatedKeys;
    }
}
