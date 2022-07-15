using LetsMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Views.Interfaces
{
    public interface IProductView
    {
        Product GetProduct(Product? product = null);

        bool Confirm(string msg, bool defaultValue = false);

        Product Select(string msg, List<Product> products);

        void ShowError(string msg);
        void WriteMessage(string msg);
    }
}
