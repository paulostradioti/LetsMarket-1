using LetsMarket.Models;
using LetsMarket.Repositories.Interfaces;

namespace LetsMarket.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
    }
}
