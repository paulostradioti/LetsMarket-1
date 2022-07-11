using CsvHelper.Configuration;
using LetsMarket.Models;

namespace LetsMarket
{
    public class CsvReaderClassMap : ClassMap<Product>
    {
        public CsvReaderClassMap()
        {
            Map(m => m.Codigo).Name("codbar");
            Map(m => m.Description).Name("desc_sem_acento");
            Map(m => m.Price).Ignore();
        }
    }
}
