using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Models
{
    internal class CartItem
    {
        private static int _longestWord;
        private string _description;

        public static void SetSize(int size) => _longestWord = size;
        public string Code { get; set; }
        public string Description
        {
            get => _description;
            set
            {
                _description = value.PadRight(_longestWord + 5);
            }
        }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get => Quantity * UnitPrice; }

        public override string ToString()
        {
            return Description;
        }
    }
}
