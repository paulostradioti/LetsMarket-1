using LetsMarket.Models;
using LetsMarket.Repositories.Interfaces;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace LetsMarket.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : Entity
    {

        private readonly string _fileName;
        private List<T> _items;
        private long _count = 0;

        protected Repository()
        {
            _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{typeof(T).Name.ToLower()}s.xml");
            Load();
        }

        private void Load()
        {
            if (File.Exists(_fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                using (TextReader reader = new StreamReader(_fileName))
                {
                    var items = serializer.Deserialize(reader) as List<T>;
                    foreach (var item in items)
                    {
                        _count++;
                        item.SetId(_count);
                    }

                    _items = items ?? new List<T>();
                }
            }
            else
            {
                _items = new List<T>();
            }
        }

        private void Save()
        {
            Console.WriteLine("Salvando...");
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (TextWriter writer = new StreamWriter(_fileName))
            {
                serializer.Serialize(writer, _items);
            }
            Console.WriteLine("Salvo.");
        }

        public void Add(T model)
        {
            _count++;
            model.SetId(_count);
            _items.Add(model);
            Save();
        }

        public void Remove(T model)
        {
            var item = _items.Find(i => i.GetId() == model.GetId());
            _items.Remove(item);
            Save();
        }

        public List<T> GetAll() => _items.AsReadOnly().ToList();

        public void Update(T model)
        {
            var item = _items.FirstOrDefault(i => i.GetId() == model.GetId());
            var itemIndex = _items.IndexOf(item);
            _items.RemoveAt(itemIndex);
            _items.Insert(itemIndex, model);

            Save();
        }
    }
}
