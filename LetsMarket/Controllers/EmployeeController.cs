using BetterConsoleTables;
using LetsMarket.Models;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket
{
    public class EmployeeController
    {
        public static void CadastrarFuncionarios()
        {
            var empregado = Prompt.Bind<Employee>();
            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            Repository.Funcionarios.Add(empregado);
            Repository.Save(DatabaseOption.Funcionarios);
        }

        private static string CreateLoginSuggestionBasedOnName(string nome)
        {
            var parts = nome?.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var suggestion = parts?.Length > 0 ? (parts.Length > 1 ? $"{parts[0]}.{parts[parts.Length - 1]}" : $"{parts[0]}") : "";

            return suggestion.ToLower();
        }

        public static void ListarFuncionarios()
        {
            Console.WriteLine("Listando Funcionários");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Repository.Funcionarios);
            Console.WriteLine(table.ToString());
        }

        public static void EditarFuncionarios()
        {
            var employee = Prompt.Select("Selecione o Funcionário para Editar", Repository.Funcionarios, defaultValue: Repository.Funcionarios[0]);

            Prompt.Bind(employee);

            Repository.Save(DatabaseOption.Funcionarios);
        }

        public static void RemoverFuncionarios()
        {
            if (Repository.Funcionarios.Count == 1)
            {
                ConsoleInput.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var employee = Prompt.Select("Selecione o Funcionário para Remover", Repository.Funcionarios);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Repository.Funcionarios.Remove(employee);
            Repository.Save(DatabaseOption.Funcionarios);
        }
    }
}