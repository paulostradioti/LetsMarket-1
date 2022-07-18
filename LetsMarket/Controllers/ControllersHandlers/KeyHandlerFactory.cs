using LetsMarket.Models;

namespace LetsMarket.Controllers.ControllersHandlers
{
    public class KeyHandlerFactory : IKeyHandlerFactory
    {
        public static Dictionary<ConsoleKey, IKeyHandler> keys = new Dictionary<ConsoleKey, IKeyHandler>()
        {
            { ConsoleKey.UpArrow, new UpArrow() },
            { ConsoleKey.PageUp, new UpArrow() },
            { ConsoleKey.PageDown, new DownArrow() },
            { ConsoleKey.DownArrow, new DownArrow() },
            { ConsoleKey.RightArrow, new Enter() },
            { ConsoleKey.Enter, new Enter() },
            { ConsoleKey.Escape, new Escape() },
            { ConsoleKey.LeftArrow, new Escape() },
            { ConsoleKey.Backspace, new Escape() }
        };

        public IKeyHandler GetHandler(ConsoleKey key)
        {
            if (keys.ContainsKey(key))
                return keys[key];

            return null;
        }
        public class UpArrow : IKeyHandler
        {
            public Menu HandleKey(Menu menu)
            {
                menu.selectedIndex = Math.Max(menu.selectedIndex - 1, 0);
                return menu;
            }
        }

        public class DownArrow : IKeyHandler
        {
            public Menu HandleKey(Menu menu)
            {
                menu.selectedIndex = Math.Min(menu.selectedIndex + 1, Math.Max(menu.items.Count - 1, 0));
                return menu;
            }
        }

        public class Escape : IKeyHandler
        {
            public Menu HandleKey(Menu menu)
            {
                if (menu.parent != null)
                    return menu.parent;

                return menu;
            }
        }

        public class Enter : IKeyHandler
        {
            public Menu HandleKey(Menu menu)
            {
                return menu.items[menu.selectedIndex];
            }
        }
    }
}
