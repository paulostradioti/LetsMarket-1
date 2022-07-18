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
    }
}
