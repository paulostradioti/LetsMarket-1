using BetterConsoleTables;
using LetsMarket.Models;
using Sharprompt;

namespace LetsMarket
{
    public class CartController
    {

        public static void Sell()
        {
            var total = decimal.Zero;
            var max = Repository.Products.Max(x => x.Description.Length);
            CartItem.SetSize(max);

            var salesItem = new List<CartItem>();


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

            var produtos = Repository.Products.ToList();
            var sair = new Product { Code = "-1", Description = "Sair", Price = 0 };
            var fecharVenda = new Product { Code = "-1", Description = "Fechar Venda", Price = 0 };
            var cancelarItem = new Product { Code = "-1", Description = "Cancelar Item", Price = 0 };

            produtos.Add(cancelarItem);
            produtos.Add(fecharVenda);
            produtos.Add(sair);

            Product produto = null;
            do
            {
                Console.Clear();
                Console.WriteLine("EFETUANDO UMA VENDA");

                var relatorio = new Table(TableConfiguration.UnicodeAlt());
                var maiorColuna = Repository.Products.Max(x => x.Description);

                if (salesItem.Count > 0)
                {
                    relatorio.From<CartItem>(salesItem);
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
                        Code = produto.Code,
                        Description = produto.Description,
                        UnitPrice = produto.Price,
                        Quantity = quantidade
                    };
                    salesItem.Add(item);
                    total += item.Subtotal;
                }

                if (produto == cancelarItem)
                {
                    Console.Clear();
                    Console.WriteLine("Selecione o item a ser cancelado");
                    var item = Prompt.Select("Selecione o item a ser cancelado", salesItem);
                    salesItem.Remove(item);

                    total -= item.UnitPrice;
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