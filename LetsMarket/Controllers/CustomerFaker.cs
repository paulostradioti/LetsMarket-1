using Bogus;
using Bogus.Extensions.Brazil;
using LetsMarket.Models;

namespace LetsMarket
{
    public static class CustomerFaker
    {
        public static Faker<Customer> Generate()
        {
            Faker<Customer> customer = new Faker<Customer>("pt_BR")
                .RuleFor(s => s.Name, f => f.Person.FullName)
                .RuleFor(s => s.Document, f => f.Person.Cpf())
                .RuleFor(s => s.Category, f => f.PickRandom<CustomerCategory>());

            return customer;
        }
    }
}
