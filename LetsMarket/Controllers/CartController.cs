using BetterConsoleTables;
using LetsMarket.Models;
using Sharprompt;

namespace LetsMarket
{
    public class CartController
    {

        public static void EfetuarVenda()
        {
            var total = decimal.Zero;
            var max = Repository.Produtos.Max(x => x.Description.Length);
            CartItem.SetTamanho(max);

            var itensVenda = new List<CartItem>();


            /*
            var documento = Prompt.Input<string>("Digite o documento para identificar o cliente ou [ENTER] para continuar");
            if (!string.IsNullOrEmpty(documento))
            {
                var nomeCliente = "";
                foreach (var cliente in Database.Clientes)
                {
                    if (cliente.Documento == documento)
                        nomeCliente = cliente.Nome;
                }

                if (!string.IsNullOrEmpty(nomeCliente))
                    Console.WriteLine($"{nomeCliente}");
            }
            */

            var produtos = Repository.Produtos.ToList();
            var sair = new Product { Codigo = "-1", Description = "Sair", Price = 0 };
            var fecharVenda = new Product { Codigo = "-1", Description = "Fechar Venda", Price = 0 };
            var cancelarItem = new Product { Codigo = "-1", Description = "Cancelar Item", Price = 0 };

            produtos.Add(cancelarItem);
            produtos.Add(fecharVenda);
            produtos.Add(sair);

            Product produto = null;
            do
            {
                Console.Clear();
                Console.WriteLine("EFETUANDO UMA VENDA");

                var relatorio = new Table(TableConfiguration.UnicodeAlt());
                var maiorColuna = Repository.Produtos.Max(x => x.Description);

                if (itensVenda.Count > 0)
                {
                    relatorio.From<CartItem>(itensVenda);
                    Console.WriteLine(relatorio.ToString());
                }

                Console.WriteLine();
                Console.WriteLine();

                // Early Return
                produto = Prompt.Select("Selecione o produto", produtos);
                if (produto != sair && produto != fecharVenda && produto != cancelarItem)
                {
                    var quantidade = Prompt.Input<int>("Informe a quantidade", defaultValue: 1);
                    var item = new CartItem
                    {
                        Codigo = produto.Codigo,
                        Descricao = produto.Description,
                        PrecoUnitario = produto.Price,
                        Quantidade = quantidade
                    };
                    itensVenda.Add(item);
                    total += item.Subtotal;
                }

                if (produto == cancelarItem)
                {
                    Console.Clear();
                    Console.WriteLine("Selecione o item a ser cancelado");
                    var item = Prompt.Select("Selecione o item a ser cancelado", itensVenda);
                    itensVenda.Remove(item);

                    total -= item.PrecoUnitario;
                }
            } while (produto != sair && produto != fecharVenda);

            if (produto == fecharVenda)
            {
                var cor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"TOTAL DA COMPRA: {total}");
                Console.ForegroundColor = cor;
                Console.ReadKey();
            }

            produtos.Remove(sair);
            produtos.Remove(fecharVenda);
            produtos.Remove(cancelarItem);

            return;
        }
    }
}