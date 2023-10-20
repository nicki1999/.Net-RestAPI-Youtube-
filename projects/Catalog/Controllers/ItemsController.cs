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
       public IEnumerable<ItemDto> GetItems()
       {
        var items = repository.GetItems().Select(item => item.AsDto());
        return items;
       }

        //Get /items/{id}
       [HttpGet("{id}")]

       //ActionResult allows for multiple datatype to be returned from a function in this case it would be null and item itself
       public ActionResult<ItemDto> GetItem(Guid id)
       {
            var item = repository.GetItem(id);
            if (item is null)
            {
                //this function returns status code:404
                return NotFound();
            }
            return item.AsDto();
       }
    }
}