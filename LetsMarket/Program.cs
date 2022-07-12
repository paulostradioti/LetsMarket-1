using LetsMarket.Repositories;
using Sharprompt;

namespace LetsMarket
{
    public class Program
    {     
        static void Main()
        {
            DatabaseInitializer.Initialize();
            ConfigurePrompt();
            Console.Title = "Let's Store";

            ValidateLogin();

            var menu = new MenuItem("Menu Principal");

            var products = new MenuItem("Produtos");
            products.Add(new MenuItem("Cadastrar Produtos", ProductController.RegisterProduct));
            products.Add(new MenuItem("Listar Produtos", ProductController.ListProducts));
            products.Add(new MenuItem("Editar Produtos", ProductController.UpdateProduct));
            products.Add(new MenuItem("Remover Produtos", ProductController.RemoveProduct));

            var employees = new MenuItem("Funcionários");
            employees.Add(new MenuItem("Cadastrar Funcionários", EmployeeController.RegisterEmployee));
            employees.Add(new MenuItem("Listar Funcionários", EmployeeController.ListEmployees));
            employees.Add(new MenuItem("Editar Funcionários", EmployeeController.UpdateEmployee));
            employees.Add(new MenuItem("Remover Funcionários", EmployeeController.RemoveEmployee));

            var customers = new MenuItem("Clientes");
            customers.Add(new MenuItem("Cadastrar Clientes", CustomerController.RegisterCustomer));
            customers.Add(new MenuItem("Listar Clientes", CustomerController.ListCustomers));
            customers.Add(new MenuItem("Editar Clientes", CustomerController.UpdateCustomer));
            customers.Add(new MenuItem("Remover Clientes", CustomerController.RemoveCustomer));

            var vendas = new MenuItem("Vendas");
            vendas.Add(new MenuItem("Efetuar Venda", CartController.Sell));

            menu.Add(products);
            menu.Add(employees);
            menu.Add(customers);
            menu.Add(vendas);
            menu.Add(new MenuItem("Sair", () => Environment.Exit(0)));

            menu.Execute();
        }

        private static void ConfigurePrompt()
        {
            Prompt.ColorSchema.Answer = ConsoleColor.White;
            Prompt.ColorSchema.Select = ConsoleColor.White;

            Prompt.Symbols.Prompt = new Symbol("", "");
            Prompt.Symbols.Done = new Symbol("", "");
            Prompt.Symbols.Error = new Symbol("", "");
        }

        private static void ValidateLogin()
        {
            var loggedIn = false;
            var attempts = 0;

            do
            {
                attempts++;
                Console.Clear();

                if (attempts > 1)
                {
                    Console.WriteLine(Environment.NewLine);
                    ConsoleInput.WriteError("DADOS INCORRETOS");
                    Console.WriteLine(Environment.NewLine);
                }

                Console.WriteLine("SYSTEM LOGIN");

                var username = ConsoleInput.GetString("login");
                var password = ConsoleInput.GetPassword("senha");

                if (IsLoginValid(username, password))
                    loggedIn = true;

            } while (!loggedIn);

        }

        private static bool IsLoginValid(string? username, string password)
        {
            var employeesRepository = new EmployeeRepository();
            foreach (var user in employeesRepository.GetAll())
            {
                if (user.Login == username && user.Password == password)
                    return true;
            }

            return false;
        }
    }
}