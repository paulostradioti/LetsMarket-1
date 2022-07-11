using BetterConsoleTables;
using LetsMarket.Models;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket
{
    public class ClientController
    {
        public static void CadastrarClientes()
        {
            var empregado = Prompt.Bind<Client>();

            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            Repository.Clientes.Add(empregado);
            Repository.Save(DatabaseOption.Clients);
        }

        public static void ListarClientes()
        {
            Console.WriteLine("Listando Clientes");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Repository.Clientes);
            Console.WriteLine(table.ToString());
        }

        public static void EditarClientes()
        {
            var client = Prompt.Select("Selecione o Cliente para Editar", Repository.Clientes, defaultValue: Repository.Clientes[0]);

            Prompt.Bind(client);

            Repository.Save(DatabaseOption.Clients);
        }

        public static void RemoverClientes()
        {
            if (Repository.Clientes.Count == 1)
            {
                ConsoleInput.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var client = Prompt.Select("Selecione o Cliente para Remover", Repository.Clientes);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Repository.Clientes.Remove(client);
            Repository.Save(DatabaseOption.Clients);
        }
    }
}