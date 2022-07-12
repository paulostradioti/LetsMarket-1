using CsvHelper;
using LetsMarket.Models;
using System.Globalization;

namespace LetsMarket.Repositories
{
    public static class DatabaseInitializer
    {

        public static void Initialize()
        {
            var employeeRepository = new EmployeeRepository();
            var productRepository = new ProductRepository();
            var customerRepository = new CustomerRepository();

            var employees = employeeRepository.GetAll();
            var products = productRepository.GetAll();
            var customers = customerRepository.GetAll();
            
            if (employees.Count == 0)
            {
                employeeRepository.Add(new Employee { Name = "Admin", Login = "admin", Password = "admin" });
            }

            if (products.Count == 0 && File.Exists("Database/data.csv"))
            {
                var faker = new Bogus.DataSets.Commerce();

                using (var reader = new StreamReader("Database/data.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CsvReaderClassMap>();
                    products = csv.GetRecords<Product>().ToList();
                    products = products.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
                    products.ForEach(x => x.Price = decimal.Parse(faker.Price()));

                    foreach(var product in products)
                    {
                        productRepository.Add(product);
                    }
                }
            }

            if (customers.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                    customerRepository.Add(CustomerFaker.Generate());
            }
        }
    }
}
