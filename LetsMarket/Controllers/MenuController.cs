using LetsMarket.Controllers.ControllersInterface;
using LetsMarket.Models;
using LetsMarket.Views.ViewInterface;

namespace LetsMarket.Controllers
{
    internal class MenuController : IMenuController
    {
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

        public void RunMenu(Menu menu, IMenuView menuView)
        {
            if (menu.Type == MenuType.Submenu)
            {
                if (menu.items.Count == 0) return;

                var key = menuView.ShowMenu(menu);
                HandleKey(key, menu, menuView);

            }
            else if (menu.Type == MenuType.Command)
            {
                menu.action();
                RunMenu(menu, menuView);
            }
        }

        public void HandleKey(ConsoleKey key, Menu menu, IMenuView menuView)
        {
            switch (key)
            {
                case ConsoleKey.PageUp:
                case ConsoleKey.UpArrow:
                    menu.selectedIndex = Math.Max(menu.selectedIndex - 1, 0);
                    RunMenu(menu, menuView);
                    break;
                case ConsoleKey.PageDown:
                case ConsoleKey.DownArrow:
                    menu.selectedIndex = Math.Min(menu.selectedIndex + 1, Math.Max(menu.items.Count - 1, 0));
                    RunMenu(menu, menuView);
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.RightArrow:
                    RunMenu(menu.items[menu.selectedIndex], menuView);
                    break;
                case ConsoleKey.Escape:
                    if (menu == Menu._root)
                        return;
                    RunMenu(menu.parent, menuView);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.Backspace:
                    if (menu == Menu._root)
                        return;
                    RunMenu(menu.parent, menuView);
                    break;
                default:
                    break;
            }
        }
    }
}
