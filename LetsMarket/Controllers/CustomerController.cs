using BetterConsoleTables;
using LetsMarket.Models;
using LetsMarket.Repositories;
using Sharprompt;

namespace LetsMarket
{
    public class CustomerController
    {
        public static void AddCustomer()
        {
            var employee = Prompt.Bind<Customer>();

            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            var customerRepository = new CustomerRepository();

            customerRepository.Add(employee);
        }

        public static void ListCustomers()
        {
            var customerRepository = new CustomerRepository();
            Console.WriteLine("Listando Clientes");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(customerRepository.GetAll());
            Console.WriteLine(table.ToString());
        }

        public static void UpdateCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customers = customerRepository.GetAll();
            var customer = Prompt.Select("Selecione o Cliente para Editar", customers, defaultValue: customers[0]);

            Prompt.Bind(customer);
            customerRepository.Update(customer);
        }

        public static void RemoveCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customers = customerRepository.GetAll();
            if (customers.Count == 1)
            {
                ConsoleInput.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var customer = Prompt.Select("Selecione o Cliente para Remover", customers);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            customerRepository.Remove(customer);

        }
    }
}