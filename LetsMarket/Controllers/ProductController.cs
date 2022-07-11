using BetterConsoleTables;
using LetsMarket.Models;
using Sharprompt;

namespace LetsMarket
{
    public class ProductController
    {
        public static void RegisterProduct()
        {
            var product = Prompt.Bind<Product>();

            if (!Prompt.Confirm("Deseja Salvar?"))
                return;

            Repository.Products.Add(product);
            Repository.Save(DatabaseOption.Products);
        }

        public static void ListProducts()
        {
            Console.WriteLine("Listando Produtos");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Repository.Products);
            Console.WriteLine(table.ToString());
        }

        public static void UpdateProduct()
        {
            var product = Prompt.Select("Selecione o Produto para Editar", Repository.Products, defaultValue: Repository.Products[0]);

            Prompt.Bind(product);

            Repository.Save(DatabaseOption.Products);
        }

        public static void RemoveProduct()
        {
            var product = Prompt.Select("Selecione o Produto para Remover", Repository.Products);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Repository.Products.Remove(product);
            Repository.Save(DatabaseOption.Products);
        }
    }
}