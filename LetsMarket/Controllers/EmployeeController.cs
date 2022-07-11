using BetterConsoleTables;
using LetsMarket.Models;
using Sharprompt;

namespace LetsMarket
{
    public class EmployeeController
    {
        public static void RegisterEmployee()
        {
            var employee = Prompt.Bind<Employee>();
            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            Repository.Employees.Add(employee);
            Repository.Save(DatabaseOption.Employees);
        }

        private static string CreateLoginSuggestionBasedOnName(string name)
        {
            var parts = name?.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var suggestion = parts?.Length > 0 ? (parts.Length > 1 ? $"{parts[0]}.{parts[parts.Length - 1]}" : $"{parts[0]}") : "";

            return suggestion.ToLower();
        }

        public static void ListEmployees()
        {
            Console.WriteLine("Listando Funcionários");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Repository.Employees);
            Console.WriteLine(table.ToString());
        }

        public static void UpdateEmployee()
        {
            var employee = Prompt.Select("Selecione o Funcionário para Editar", Repository.Employees, defaultValue: Repository.Employees[0]);

            Prompt.Bind(employee);

            Repository.Save(DatabaseOption.Employees);
        }

        public static void RemoveEmployee()
        {
            if (Repository.Employees.Count == 1)
            {
                ConsoleInput.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var employee = Prompt.Select("Selecione o Funcionário para Remover", Repository.Employees);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Repository.Employees.Remove(employee);
            Repository.Save(DatabaseOption.Employees);
        }
    }
}