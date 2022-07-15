using LetsMarket.Models;
using LetsMarket.Views.Interfaces;
using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Views
{
    internal class ProductView : IProductView
    {
        public Product GetProduct(Product Product = null)
        {
            return Product == null ?
                    Prompt.Bind<Product>() :
                    Prompt.Bind(Product);
        }

        public bool Confirm(string msg, bool defaultValue = false)
        {
            return Prompt.Confirm(msg, defaultValue);
        }

        public Product Select(string msg, List<Product> Products)
        {
            return Prompt.Select(msg, Products);
        }

        public void ShowError(string msg)
        {
            ConsoleInput.WriteError(msg);
            Console.ReadKey();
        }

        public void WriteMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
