using BetterConsoleTables;
using LetsMarket.Models;
using Sharprompt;

namespace LetsMarket
{
    public class ProductController
    {
        public static void CadastrarProdutos()
        {
            var product = Prompt.Bind<Product>();

            if (!Prompt.Confirm("Deseja Salvar?"))
                return;

            Repository.Produtos.Add(product);
            Repository.Save(DatabaseOption.Products);
        }

        public static void ListarProdutos()
        {
            Console.WriteLine("Listando Produtos");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Repository.Produtos);
            Console.WriteLine(table.ToString());
        }

        public static void EditarProduto()
        {
            var produto = Prompt.Select("Selecione o Produto para Editar", Repository.Produtos, defaultValue: Repository.Produtos[0]);

            Prompt.Bind(produto);

            Repository.Save(DatabaseOption.Products);
        }

        public static void RemoverProduto()
        {
            var produto = Prompt.Select("Selecione o Produto para Remover", Repository.Produtos);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Repository.Produtos.Remove(produto);
            Repository.Save(DatabaseOption.Products);
        }
    }
}