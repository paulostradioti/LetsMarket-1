using BetterConsoleTables;
using LetsMarket.Models;
using Sharprompt;

namespace LetsMarket
{
    public class CustomerController
    {
        public static void RegisterCustomer()
        {
            var employee = Prompt.Bind<Customer>();

            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            Repository.Customers.Add(employee);
            Repository.Save(DatabaseOption.Customers);
        }

        public static void ListCustomers()
        {
            Console.WriteLine("Listando Clientes");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Repository.Customers);
            Console.WriteLine(table.ToString());
        }

        public static void UpdateCustomer()
        {
            var client = Prompt.Select("Selecione o Cliente para Editar", Repository.Customers, defaultValue: Repository.Customers[0]);

            Prompt.Bind(client);

            Repository.Save(DatabaseOption.Customers);
        }

        public static void RemoveCustomer()
        {
            if (Repository.Customers.Count == 1)
            {
                ConsoleInput.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var customer = Prompt.Select("Selecione o Cliente para Remover", Repository.Customers);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Repository.Customers.Remove(customer);
            Repository.Save(DatabaseOption.Customers);
        }
    }
}