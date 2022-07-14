using LetsMarket.Controllers.ControllersInterface;
using LetsMarket.Models;
using LetsMarket.Views.ViewInterface;
using Sharprompt;

namespace LetsMarket.Controllers
{
    public class LoginController : ILoginController
    {
        private static readonly string ATTEMPTS_ERROR = "Muitas tentativas";
        public Employee Login(ILoginView loginView)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                var login = loginView.GetLogin();
                var password = loginView.GetPassword();

                try
                {
                    var employee = ValidateLogin(login, password);
                    return employee;
                }
                catch (Exception ex)
                {
                    loginView.ShowError(ex.Message);
                }
            }

            loginView.ShowError(ATTEMPTS_ERROR);

            Environment.Exit(0);
            return new Employee();
        }

        public Employee ValidateLogin(string login, string password)
        {
            var employee = new Employee("nome", "login", "senha", EmployeeCategory.Manager); //FIXME

            if (employee == null) throw new Exception("Usuário não encontrado");
            if (!employee.ValidatePassword(password)) throw new Exception("Senha incorreta");

            return employee;
        }
    }
}
