using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository
    {
        public readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), CreatedDate = DateTimeOffset.UtcNow, Name = "Potion", Price = 9},
            new Item {Id = Guid.NewGuid(), CreatedDate = DateTimeOffset.UtcNow, Name = "IronSword", Price = 20},
            new Item {Id = Guid.NewGuid(), CreatedDate = DateTimeOffset.UtcNow, Name = "Bronze Shield", Price = 18},
        }; 

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item? GetItem(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return item;
        }
    }
}