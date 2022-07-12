using BetterConsoleTables;
using LetsMarket.Models;
using LetsMarket.Repositories;
using Sharprompt;

namespace LetsMarket
{
    public class EmployeeController
    {
        public static void RegisterEmployee()
        {
            var employeeRepository = new Repositories.EmployeeRepository();
            var employee = new Employee();
            employee = Prompt.Bind<Employee>();
            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            employeeRepository.Add(employee);
        }

        private static string CreateLoginSuggestionBasedOnName(string name)
        {
            var parts = name?.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var suggestion = parts?.Length > 0 ? (parts.Length > 1 ? $"{parts[0]}.{parts[parts.Length - 1]}" : $"{parts[0]}") : "";

            return suggestion.ToLower();
        }

        public static void ListEmployees()
        {
            var employeeRepository = new EmployeeRepository();
            Console.WriteLine("Listando Funcionários");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(employeeRepository.GetAll());
            Console.WriteLine(table.ToString());
        }

        public static void UpdateEmployee()
        {
            var employeeRepository = new EmployeeRepository();
            var employees = employeeRepository.GetAll();

            var employee = Prompt.Select("Selecione o Funcionário para Editar", employees, defaultValue: employees[0]);

            Prompt.Bind(employee);

            employeeRepository.Update(employee);
        }

        public static void RemoveEmployee()
        {
            var employeeRepository = new EmployeeRepository();

            var employees = employeeRepository.GetAll();

            if (employees.Count == 1)
            {
                ConsoleInput.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var employee = Prompt.Select("Selecione o Funcionário para Remover", employees);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            employeeRepository.Remove(employee);
        }
    }
}