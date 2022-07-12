using LetsMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Controllers.ControllersInterface
{
    public interface IMenuController
    {
        public Menu CreateMenu();
        public void RunMenu(Menu menu);
    }
}
