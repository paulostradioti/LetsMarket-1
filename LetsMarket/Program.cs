using Sharprompt;

namespace LetsMarket
{
    public class Program
    {     
        static void Main()
        {
            ConfiguraPrompt();
            Console.Title = "Let's Store";

            VerificaLogin();

            var menu = new MenuItem("Menu Principal");

            var produtos = new MenuItem("Produtos");
            produtos.Add(new MenuItem("Cadastrar Produtos", ProductController.CadastrarProdutos));
            produtos.Add(new MenuItem("Listar Produtos", ProductController.ListarProdutos));
            produtos.Add(new MenuItem("Editar Produtos", ProductController.EditarProduto));
            produtos.Add(new MenuItem("Remover Produtos", ProductController.RemoverProduto));

            var funcionarios = new MenuItem("Funcionários");
            funcionarios.Add(new MenuItem("Cadastrar Funcionários", EmployeeController.CadastrarFuncionarios));
            funcionarios.Add(new MenuItem("Listar Funcionários", EmployeeController.ListarFuncionarios));
            funcionarios.Add(new MenuItem("Editar Funcionários", EmployeeController.EditarFuncionarios));
            funcionarios.Add(new MenuItem("Remover Funcionários", EmployeeController.RemoverFuncionarios));

            var clientes = new MenuItem("Clientes");
            clientes.Add(new MenuItem("Cadastrar Clientes", ClientController.CadastrarClientes));
            clientes.Add(new MenuItem("Listar Clientes", ClientController.ListarClientes));
            clientes.Add(new MenuItem("Editar Clientes", ClientController.EditarClientes));
            clientes.Add(new MenuItem("Remover Clientes", ClientController.RemoverClientes));

            var vendas = new MenuItem("Vendas");
            vendas.Add(new MenuItem("Efetuar Venda", CartController.EfetuarVenda));

            menu.Add(produtos);
            menu.Add(funcionarios);
            menu.Add(clientes);
            menu.Add(vendas);
            menu.Add(new MenuItem("Sair", () => Environment.Exit(0)));

            menu.Execute();
        }

        private static void ConfiguraPrompt()
        {
            Prompt.ColorSchema.Answer = ConsoleColor.White;
            Prompt.ColorSchema.Select = ConsoleColor.White;

            Prompt.Symbols.Prompt = new Symbol("", "");
            Prompt.Symbols.Done = new Symbol("", "");
            Prompt.Symbols.Error = new Symbol("", "");
        }

        private static void VerificaLogin()
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

                if (LoginIsValid(username, password))
                    loggedIn = true;

            } while (!loggedIn);

        }

        private static bool LoginIsValid(string? username, string password)
        {
            foreach (var usuario in Repository.Funcionarios)
            {
                if (usuario.Login == username && usuario.Password == password)
                    return true;
            }

            return false;
        }
    }
}