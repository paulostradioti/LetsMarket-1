using LetsMarket.Models;
using LetsMarket.Repositories.Interfaces;

namespace LetsMarket.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        protected override void InitializeData()
        {
            if (Count == 0)
            {
                for (int i = 0; i < 10; i++)
                    Add(CustomerFaker.Generate());
            }
        }
    }
}
