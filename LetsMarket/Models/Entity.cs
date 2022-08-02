using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Models
{
    [Serializable]
    public abstract class Entity
    {
        protected long Id { get; set; }

        public void SetId(long id)
        {
            Id = id;
        }

        public long GetId()
        {
            return Id;
        }
    }
}
