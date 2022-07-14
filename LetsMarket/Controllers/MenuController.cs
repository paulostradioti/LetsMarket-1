using LetsMarket.Controllers.ControllersHandlers;
using LetsMarket.Controllers.ControllersInterface;
using LetsMarket.Models;
using LetsMarket.Views.ViewInterface;

namespace LetsMarket.Controllers
{
    internal class MenuController : IMenuController
    {
        private IMenuView _menuView;
        private IKeyHandlerFactory _keyHandlerFactory;

        public MenuController(IMenuView menuView, IKeyHandlerFactory keyHandlerFactory)
        {
            _menuView = menuView;
            _keyHandlerFactory = keyHandlerFactory;
        }
        public static List<ConsoleKey> acceptedKeys = new List<ConsoleKey>() 
        { 
            ConsoleKey.PageUp,
            ConsoleKey.UpArrow,
            ConsoleKey.PageDown,
            ConsoleKey.DownArrow,
            ConsoleKey.Enter,
            ConsoleKey.RightArrow,
            ConsoleKey.Escape,
            ConsoleKey.LeftArrow,
            ConsoleKey.Backspace
        };
        public Menu CreateMenu()
        {
            var menu = new Menu("Menu Principal");

            var products = new Menu("Produtos");
            products.Add(new Menu("Cadastrar Produtos", ProductController.RegisterProduct));
            products.Add(new Menu("Listar Produtos", ProductController.ListProducts));
            products.Add(new Menu("Editar Produtos", ProductController.UpdateProduct));
            products.Add(new Menu("Remover Produtos", ProductController.RemoveProduct));

            var employees = new Menu("Funcionários");
            employees.Add(new Menu("Cadastrar Funcionários", EmployeeController.RegisterEmployee));
            employees.Add(new Menu("Listar Funcionários", EmployeeController.ListEmployees));
            employees.Add(new Menu("Editar Funcionários", EmployeeController.UpdateEmployee));
            employees.Add(new Menu("Remover Funcionários", EmployeeController.RemoveEmployee));

            var customers = new Menu("Clientes");
            customers.Add(new Menu("Cadastrar Clientes", CustomerController.RegisterCustomer));
            customers.Add(new Menu("Listar Clientes", CustomerController.ListCustomers));
            customers.Add(new Menu("Editar Clientes", CustomerController.UpdateCustomer));
            customers.Add(new Menu("Remover Clientes", CustomerController.RemoveCustomer));

            var vendas = new Menu("Vendas");
            vendas.Add(new Menu("Efetuar Venda", CartController.Sell));

            menu.Add(products);
            menu.Add(employees);
            menu.Add(customers);
            menu.Add(vendas);
            menu.Add(new Menu("Sair", () => Environment.Exit(0)));

            return menu;
        }

        public void RunMenu(Menu menu)
        {

            if (menu.Type == MenuType.Submenu)
            {
                if (menu.items.Count == 0) return;

                var key = _menuView.ShowMenu(menu);
                var keyHandler = _keyHandlerFactory.GetHandler(key);

                var updatedMenu = keyHandler.HandleKey(menu);
                RunMenu(updatedMenu);

            }
            else if (menu.Type == MenuType.Command)
            {
                menu.action();
                RunMenu(menu.parent);
            }
        }
    }
}
