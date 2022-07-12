using LetsMarket.Models;
using LetsMarket.Views.Interfaces;
using Sharprompt;

namespace LetsMarket.Views
{
    public class EmployeeView : IEmployeeView
    {

        public Employee GetEmployee(Employee employee = null)
        {
            return employee == null ? 
                    Prompt.Bind<Employee>() : 
                    Prompt.Bind(employee);
        }

        public bool Confirm(string msg, bool defaultValue = false)
        {
            return Prompt.Confirm(msg, defaultValue);
        }

        public Employee Select(string msg, List<Employee> employees)
        {
            return Prompt.Select(msg, employees);
        }

        public void ShowError(string msg)
        {
            ConsoleInput.WriteError(msg);
            Console.ReadKey();
        }

        public void WriteMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
