/*using Catalog.Entities;

namespace Catalog.Repositories
{

    public class InMemItemsRepository: IItemsRepository
    {
        public readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), CreatedDate = DateTimeOffset.UtcNow, Name = "Potion", Price = 9},
            new Item {Id = Guid.NewGuid(), CreatedDate = DateTimeOffset.UtcNow, Name = "IronSword", Price = 20},
            new Item {Id = Guid.NewGuid(), CreatedDate = DateTimeOffset.UtcNow, Name = "Bronze Shield", Price = 18},
        }; 

        public IEnumerable<Item> GetItemsAsync()
        {
            return items;
        }

        public Item? GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return item;
        }

        public void CreateItemAsync(Item item)
        {
            items.Add(item);
        }

        public void UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        // Would not need a Dto bc there is only one variable that we need (id)
        public void DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}
*/