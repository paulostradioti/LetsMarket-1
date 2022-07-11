using CsvHelper;
using LetsMarket.Models;
using System.Globalization;
using System.Xml.Serialization;

namespace LetsMarket
{
    public enum DatabaseOption { Employees, Products, Customers }

    public class Repository
    {
        private static readonly string _rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string _employeesDb = Path.Combine(_rootDirectory, "employees.xml");
        private static readonly string _productsDb = Path.Combine(_rootDirectory, "products.xml");
        private static readonly string _clientsDb = Path.Combine(_rootDirectory, "customers.xml");

        public static List<Employee> Employees = new List<Employee>();
        public static List<Product> Products = new List<Product>();
        public static List<Customer> Customers = new List<Customer>();

        static Repository()
        {
            InitializeDatabase();
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists(_employeesDb))
            {
                Employees.Add(new Employee { Name = "Admin", Login = "admin", Password = "admin" });
                Save(DatabaseOption.Employees);
            }

            if (!File.Exists(_productsDb) && File.Exists("Database/data.csv"))
            {
                var faker = new Bogus.DataSets.Commerce();

                using (var reader = new StreamReader("Database/data.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CsvReaderClassMap>();
                    var products = csv.GetRecords<Product>().ToList();
                    Products = products.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
                    products.ForEach(x => x.Price = decimal.Parse(faker.Price()));

                    Save(DatabaseOption.Products);
                }
            }

            if (!File.Exists(_clientsDb))
            {
                for (int i = 0; i < 10; i++)
                    Customers.Add(CustomerFaker.Generate());
                
                Save(DatabaseOption.Customers);
            }

            Load(DatabaseOption.Employees);
            Load(DatabaseOption.Products);
            Load(DatabaseOption.Customers);
        }

        private static void Load(DatabaseOption options)
        {
            if (options == DatabaseOption.Employees)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Employee>));
                using (TextReader reader = new StreamReader(_employeesDb))
                {
                    var employees = employeeSerializer.Deserialize(reader) as List<Employee>;
                    Employees = employees ?? new List<Employee>();
                }
            }

            if (options == DatabaseOption.Products)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Product>));
                using (TextReader reader = new StreamReader(_productsDb))
                {
                    var funcionarios = employeeSerializer.Deserialize(reader) as List<Product>;
                    Products = funcionarios ?? new List<Product>();
                }
            }

            if (options == DatabaseOption.Customers)
            {
                XmlSerializer clientSerializer = new XmlSerializer(typeof(List<Customer>));
                using (TextReader reader = new StreamReader(_clientsDb))
                {
                    var funcionarios = clientSerializer.Deserialize(reader) as List<Customer>;
                    Customers = funcionarios ?? new List<Customer>();
                }
            }
        }

        public static void Save(DatabaseOption options)
        {
            Console.WriteLine("Salvando...");

            if (options == DatabaseOption.Employees)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Employee>));
                using (TextWriter writer = new StreamWriter(_employeesDb))
                {
                    employeeSerializer.Serialize(writer, Employees);
                }
            }

            if (options == DatabaseOption.Products)
            {
                XmlSerializer productSerializer = new XmlSerializer(typeof(List<Product>));
                using (TextWriter writer = new StreamWriter(_productsDb))
                {
                    productSerializer.Serialize(writer, Products);
                }
            }

            if (options == DatabaseOption.Customers)
            {
                XmlSerializer clientSerializer = new XmlSerializer(typeof(List<Customer>));
                using (TextWriter writer = new StreamWriter(_clientsDb))
                {
                    clientSerializer.Serialize(writer, Customers);
                }
            }
            Console.WriteLine("Salvo.");
        }
    }
}
