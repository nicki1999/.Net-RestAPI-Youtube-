using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController:ControllerBase
    {
       private readonly IItemsRepository repository;
       public ItemsController(IItemsRepository repository)
       {
        this.repository = repository;
       }

        //Get /items
        [HttpGet]
       public async Task<IEnumerable<ItemDto>> GetItemsAsync() 
       {
        var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
        return items;
       }

        //Get /items/{id}
       [HttpGet("{id}")]

       //ActionResult allows for multiple datatype to be returned from a function in this case it would be null and item itself
       public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
       {
            var item = await repository.GetItemAsync(id);
            if (item is null)
            {
                //this function returns status code:404
                return NotFound();
            }
            return item.AsDto();
       }

        //POST /items
        [HttpPost]
       public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
       {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = itemDto.Name,
            CreatedDate = DateTimeOffset.UtcNow,
            Price = itemDto.Price

        };

        await repository.CreateItemAsync(item);
        //CreatedAtAction method is commonly used for POST requests to create resources.
        return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id}, item.AsDto());
       }

       //PUT /items/id

       [HttpPut("{id}")]
       public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
       {
        var existingItem = await repository.GetItemAsync(id);

        if (existingItem is null){
            return NotFound();
        }

        Item updatedItem = existingItem with {
            Name = itemDto.Name,
            Price = itemDto.Price
        };

        await repository.UpdateItemAsync(updatedItem);

        return NoContent();
       }

        // DELETE /items/id
        [HttpDelete("{id}")]
       public async Task<ActionResult> DeleteItemAsync(Guid id)
       {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null){
            return NotFound();
        }

            await repository.DeleteItemAsync(id);

            return NoContent();
       }
    }
}