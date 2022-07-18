using LetsMarket.Models;
using System.Reflection;

namespace LetsMarket.Controllers.ControllersHandlers
{
    public class KeyHandlerFactory : IKeyHandlerFactory
    {
        public static Dictionary<ConsoleKey, IKeyHandler> keys = new Dictionary<ConsoleKey, IKeyHandler>();

        public KeyHandlerFactory()
        {
            FillKeysDictionary();
        }

        private void FillKeysDictionary()
        {
            var keyHandlerTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(
                    x => x.IsAssignableTo(typeof(IKeyHandler)) 
                    && x.IsClass 
                    && !x.IsAbstract
                );

            foreach (var keyHandlerType in keyHandlerTypes)
            {
                var obj = (IKeyHandler)Activator.CreateInstance(keyHandlerType);

                foreach (var key in obj.GetAssociatedKeys())
                    keys.Add(key, obj);
            }
        }

        public IKeyHandler GetHandler(ConsoleKey key)
        {
            if (keys.ContainsKey(key))
                return keys[key];

            return null;
        }

        public class UpArrow : IKeyHandler
        {
            private List<ConsoleKey> associatedKeys = new List<ConsoleKey>() 
            {
                ConsoleKey.UpArrow,
                ConsoleKey.PageUp,
            };

            public Menu HandleKey(Menu menu)
            {
                menu.selectedIndex = Math.Max(menu.selectedIndex - 1, 0);
                return menu;
            }

            public List<ConsoleKey> GetAssociatedKeys() => associatedKeys;
        }

        public class DownArrow : IKeyHandler
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

        public class Escape : IKeyHandler
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

        public class Enter : IKeyHandler
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
}
