using LetsMarket.Models;

namespace LetsMarket.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product model);
        void Update(Product model, long currrentId);
        void Remove(Product model);
        List<Product> GetAll();
        int Count { get; }
    }
}