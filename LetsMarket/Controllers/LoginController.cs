using LetsMarket.Controllers.ControllersInterface;
using LetsMarket.Models;
using LetsMarket.Views.ViewInterface;
using Sharprompt;

namespace LetsMarket.Controllers
{
    public class LoginController : ILoginController
    {
        ILoginView _loginView;

        public LoginController(ILoginView loginView)
        {
            _loginView = loginView;
        }

        private static readonly string ATTEMPTS_ERROR = "Muitas tentativas";
        public Employee Login()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                var login = _loginView.GetLogin();
                var password = _loginView.GetPassword();

                try
                {
                    var employee = ValidateLogin(login, password);
                    return employee;
                }
                catch (Exception ex)
                {
                    _loginView.ShowError(ex.Message);
                }
            }

            _loginView.ShowError(ATTEMPTS_ERROR);

            Environment.Exit(0);
            return new Employee();
        }

        public Employee ValidateLogin(string login, string password)
        {
            var employee = new Employee()
            {
                Login = login,
            };

            if (employee == null) throw new Exception("Usuário não encontrado");
            if (!employee.ValidatePassword(password)) throw new Exception("Senha incorreta");

            return employee;
        }
    }
}
