using BetterConsoleTables;
using LetsMarket.Models;
using LetsMarket.Repositories;
using Sharprompt;

namespace LetsMarket
{
    public class ProductController
    {


        public static void AddProduct()
        {
            var productRepository = new ProductRepository();
            
            var product = Prompt.Bind<Product>();

            if (!Prompt.Confirm("Deseja Salvar?"))
                return;

            productRepository.Add(product);
        }

        public static void ListProducts()
        {
            var productRepository = new ProductRepository();
            
            Console.WriteLine("Listando Produtos");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(productRepository.GetAll());
            Console.WriteLine(table.ToString());
        }

        public static void UpdateProduct()
        {
            var productRepository =new ProductRepository();
            var products = productRepository.GetAll();
            var product = Prompt.Select("Selecione o Produto para Editar", products, defaultValue: products[0]);

            Prompt.Bind(product);
            productRepository.Update(product);
        }

        public static void RemoveProduct()
        {
            var productRepository = new ProductRepository();
            var product = Prompt.Select("Selecione o Produto para Remover", productRepository.GetAll());
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            productRepository.Remove(product);
        }
    }
}