using LetsMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Views.Interfaces
{
    public interface IEmployeeView
    {
        Employee Bind(Employee? employee = null);

        bool Confirm(string msg, bool defaultValue = false);

        Employee Select(string msg, List<Employee> employees);

        void ShowError(string msg);
        void WriteMessage(string msg);
    }
}
