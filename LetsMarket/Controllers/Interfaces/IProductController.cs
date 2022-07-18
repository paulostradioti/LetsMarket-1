using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Controllers.Interfaces
{
    public interface IProductController
    {
        void AddProduct();

        void ListProducts();

        void UpdateProduct();

        void RemoveProduct();
    }
}
