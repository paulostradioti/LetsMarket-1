using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Controllers.Interfaces
{
    public interface IEmployeeController
    {
        void AddEmployee();

        void ListEmployees();

        void UpdateEmployee();

        void RemoveEmployee();
    }
}
