using Bogus;
using Bogus.Extensions.Brazil;
using LetsMarket.Models;

namespace LetsMarket
{
    public static class ClienteFaker
    {
        public static Faker<Client> Gerar()
        {
            Faker<Client> cliente = new Faker<Client>("pt_BR")
                .RuleFor(s => s.Nome, f => f.Person.FullName)
                .RuleFor(s => s.Documento, f => f.Person.Cpf())
                .RuleFor(s => s.Category, f => f.PickRandom<ClientCategory>());

            return cliente;
        }
    }
}
