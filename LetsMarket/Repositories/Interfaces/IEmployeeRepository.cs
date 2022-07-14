using LetsMarket.Models;

namespace LetsMarket.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetByCredentials(string login, string password);
    }
}
