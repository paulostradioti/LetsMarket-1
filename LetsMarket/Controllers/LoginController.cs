using LetsMarket.Controllers.ControllersInterface;
using LetsMarket.Models;
using LetsMarket.Repositories.Interfaces;
using LetsMarket.Views.ViewInterface;

namespace LetsMarket.Controllers
{
    public class LoginController : ILoginController
    {
        ILoginView _loginView;
        IEmployeeRepository _employeeRepository;

        public LoginController(ILoginView loginView, IEmployeeRepository employeeRepository)
        {
            _loginView = loginView;
            _employeeRepository = employeeRepository;
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
            var employee = _employeeRepository.GetByCredentials(login, password);

            if (employee == null) throw new Exception("Credenciais inválidas!");

            return employee;
        }
    }
}
