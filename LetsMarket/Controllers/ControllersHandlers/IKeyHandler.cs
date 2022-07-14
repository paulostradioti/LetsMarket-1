using LetsMarket.Models;

namespace LetsMarket.Controllers.ControllersHandlers
{
    public interface IKeyHandler
    {
        public Menu HandleKey(Menu menu);
    }
}