namespace LetsMarket.Repositories.Interfaces
{
    public interface IRepository<T>
        where T: class
    {
        void Add(T model);
        void Update(T model);
        void Remove(T model);
        List<T> GetAll();
    }
}
