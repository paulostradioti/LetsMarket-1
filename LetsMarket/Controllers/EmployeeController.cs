using BetterConsoleTables;
using Sharprompt;
using LetsMarket.Repositories.Interfaces;
using LetsMarket.Views.Interfaces;
using LetsMarket.Controllers.Interfaces;

namespace LetsMarket
{
    public class EmployeeController : IEmployeeController
    {
        IEmployeeView _view;
        IEmployeeRepository _repository;

        public EmployeeController(IEmployeeView view, IEmployeeRepository repository)
        {
            _view = view;
            _repository = repository;
        }

        public void AddEmployee()
        {
            var employee = _view.Bind();
            
            if (!_view.Confirm("Deseja salvar?"))
                return;

            _repository.Add(employee);
        }

        public void ListEmployees()
        {
            _view.WriteMessage("Listando Funcionários\n");

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(_repository.GetAll());
            Console.WriteLine(table.ToString());
        }

        public void UpdateEmployee()
        {
            var employees = _repository.GetAll();

            var employee = _view.Select("Selecione o Funcionário para Editar", employees);
            employee = _view.Bind(employee);

            _repository.Update(employee);
        }

        public void RemoveEmployee()
        {
            var employees = _repository.GetAll();

            if (employees.Count == 1)
            {
                _view.ShowError("Não é possível remover todos os usuários.");
                return;
            }

            var employee = _view.Select("Selecione o Funcionário para Remover", employees);

            if (!_view.Confirm("Tem Certeza?", false))
                return;

            _repository.Remove(employee);
        }
    }
}