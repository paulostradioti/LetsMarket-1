using LetsMarket.Models;
using LetsMarket.Views.ViewInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Controllers.ControllersInterface
{
    public interface ILoginController
    {
        public Employee Login();
        public Employee ValidateLogin(string login, string password);
    }
}
