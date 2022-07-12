namespace LetsMarket.Models
{
    [Serializable]
    public abstract class Entity
    {
        private long _id;

        public void SetId(long id)
        {
            _id = id;
        }

        public long GetId()
        {
            return _id;
        }
    }
}
