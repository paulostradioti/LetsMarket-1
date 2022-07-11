using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Models
{
    internal class CartItem
    {
        private static int _maiorColuna;
        private string _descricao;
        public static void SetTamanho(int tamanho) => _maiorColuna = tamanho;
        public string Codigo { get; set; }
        public string Descricao
        {
            get => _descricao;
            set
            {
                _descricao = value.PadRight(_maiorColuna + 5);
            }
        }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal { get => Quantidade * PrecoUnitario; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
