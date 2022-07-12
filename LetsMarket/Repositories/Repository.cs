using LetsMarket.Repositories.Interfaces;
using System.Xml.Serialization;

namespace LetsMarket.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {

        private readonly string _fileName;
        private List<T> _items;

        protected Repository()
        {
            _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{typeof(T).Name.ToLower()}s.xml"); // define o nome do arquivo xml baseado no nome do tipo genérico do repositorio
            Load();
        }

        private void Load()
        {
            if (File.Exists(_fileName)) // se o arquivo existir
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                using (TextReader reader = new StreamReader(_fileName)) // cria um leitor que será destruido no fim do using
                {
                    var items = serializer.Deserialize(reader) as List<T>; // converte o arquivo XML em uma lista do tipo
                    _items = items ?? new List<T>(); // se items estiver nulo retorna uma instância da lista vazia
                }
            }
            else // se o arquivo não existir
            {
                _items = new List<T>(); // intancia a lista vazia
            }
        }

        private void Save()
        {
            Console.WriteLine("Salvando...");
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>)); // cria o serializador
            using (TextWriter writer = new StreamWriter(_fileName)) // cria o escritor de arquivo
            {
                serializer.Serialize(writer, _items); // escreve a Lista no arquivo xml
            }
            Console.WriteLine("Salvo.");
        }

        public void Add(T model)
        {
            _items.Add(model);
            Save();
        }

        public void Remove(T model)
        {
            _items.Remove(model);
            Save();
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public void Update(T model)
        {
            Save();
        }
    }
}
