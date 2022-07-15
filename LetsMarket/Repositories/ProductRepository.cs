using CsvHelper;
using LetsMarket.Models;
using LetsMarket.Repositories.Interfaces;
using System.Globalization;

namespace LetsMarket.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected override void InitializeData()
        {
            if (Count == 0 && File.Exists("Database/data.csv"))
            {
                var faker = new Bogus.DataSets.Commerce();

                using (var reader = new StreamReader("Database/data.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CsvReaderClassMap>();
                    var products = csv.GetRecords<Product>().ToList();
                    products = products.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
                    products.ForEach(x => x.Price = decimal.Parse(faker.Price()));

                    foreach (var product in products)
                    {
                        Add(product);
                    }
                }
            }
        }
    }
}
