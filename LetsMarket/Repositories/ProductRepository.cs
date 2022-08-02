using System.Data;
using CsvHelper;
using LetsMarket.Models;
using LetsMarket.Repositories.Interfaces;
using System.Globalization;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LetsMarket.Repositories
{
    public class ProductRepository : /*Repository<Product>, */ IProductRepository
    {
        private IDbConnection connection;
        public ProductRepository(IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        //protected override void InitializeData()
        //{
        //    if (Count == 0 && File.Exists("Database/data.csv"))
        //    {
        //        var faker = new Bogus.DataSets.Commerce();

        //        using (var reader = new StreamReader("Database/data.csv"))
        //        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //        {
        //            csv.Context.RegisterClassMap<CsvReaderClassMap>();
        //            var products = csv.GetRecords<Product>().ToList();
        //            products = products.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
        //            products.ForEach(x => x.Price = decimal.Parse(faker.Price()));

        //            foreach (var product in products)
        //            {
        //                Add(product);
        //            }
        //        }
        //    }
        //}
        public void Add(Product model)
        {
            var id = connection.QuerySingle<int>(
                "INSERT INTO [dbo].[Product] ([CodeBar], [Description], [UnitPrice]) " +
                "OUTPUT INSERTED.[ProductID] VALUES (@Code, @Description, @Price)",
                model);

            model.Id = id;
        }

        public void Update(Product model, long currentId)
        {
            var count = connection.Execute(
                "UPDATE [dbo].[Product] SET " +
                "[CodeBar] = @Code, " +
                "[Description] = @Description, " +
                "[UnitPrice] = @UnitPrice " +
                "WHERE [ProductID]= @ProductID;",
                new
                {
                    model.Code,
                    model.Description,
                    UnitPrice = model.Price,
                    ProductID = currentId
                });
        }

        public void Remove(Product model)
        {
            connection.Execute("DELETE FROM [dbo].[Product] WHERE [ProductID] = @Id", model.Id);
        }

        public List<Product> GetAll()
        {
            var products = connection.Query<Product>("SELECT [ProductID] AS [Id], " +
                                                     "[CodeBar] AS [Code], " +
                                                     "[Description], " +
                                                     "[UnitPrice] AS [Price]" +
                                                     "FROM [joao.correa].[dbo].[Product]").ToList();


            return products;
        }

        public int Count { get; }
    }
}
