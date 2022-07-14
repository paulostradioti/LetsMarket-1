namespace LetsMarket.Controllers.ControllersHandlers
{
    public interface IKeyHandlerFactory
    {
        public IKeyHandler GetHandler(ConsoleKey key);
    }
}