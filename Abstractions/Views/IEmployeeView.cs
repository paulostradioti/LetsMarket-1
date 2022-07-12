using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Views
{
    public class IEmployeeView
    {
        public Employee GetEmployee(Employee employee = null);

        public bool Confirm(string msg, bool defaultValue = false);

        public Employee Select(string msg, List<Employee> employees);

        public void ShowError(string msg);
    }
}
