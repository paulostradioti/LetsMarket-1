using LetsMarket.Models;
using LetsMarket.Repositories.Interfaces;

namespace LetsMarket.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public Employee GetByCredentials(string login, string password)
        {
            return Get(e => e.Login == login && e.Password == password);
        }

        protected override void InitializeData()
        {
            if (Count == 0)
            {
                Add(new Employee { Name = "Admin", Login = "admin", Password = "admin" });
            }
        }
    }
}
