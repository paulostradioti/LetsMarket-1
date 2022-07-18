using BetterConsoleTables;
using LetsMarket.Controllers.Interfaces;
using LetsMarket.Models;
using LetsMarket.Repositories;
using LetsMarket.Repositories.Interfaces;
using LetsMarket.Views.Interfaces;
using Sharprompt;

namespace LetsMarket
{
    public class ProductController : IProductController
    {
        IProductView _view;
        IProductRepository _repository;

        public ProductController(IProductView view, IProductRepository repository)
        {
            _view = view;
            _repository = repository;
        }

        public void AddProduct()
        {
            var product = _view.GetProduct();

            if (!_view.Confirm("Deseja salvar?"))
                return;

            _repository.Add(product);
        }

        public void ListProducts()
        {
            _view.WriteMessage("Listando Produtos\n");

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(_repository.GetAll());
            Console.WriteLine(table.ToString());
        }

        public void UpdateProduct()
        {
            var products = _repository.GetAll();
            var product = _view.Select("Selecione o Produto para Editar", products);

            _view.GetProduct(product);
            _repository.Update(product);
        }

        public void RemoveProduct()
        {
            var products = _repository.GetAll();
            var product = _view.Select("Selecione o Produto para Remover", products);

            if (!_view.Confirm("Tem Certeza?", false))
                return;

            _repository.Remove(product);
        }
    }
}