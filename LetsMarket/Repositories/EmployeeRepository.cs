using LetsMarket.Models;
using LetsMarket.Repositories.Interfaces;

namespace LetsMarket.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public Employee GetByCredentials(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
