using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController:ControllerBase
    {
       private readonly InMemItemsRepository repository;
       public ItemsController()
       {
        repository = new InMemItemsRepository();
       }

        //Get /items
        [HttpGet]
       public IEnumerable<Item> GetItems()
       {
        var items = repository.GetItems();
        return items;
       }

        //Get /items/{id}
       [HttpGet("{id}")]

       //ActionResult allows for multiple datatype to be returned from a function in this case it would be null and item itself
       public ActionResult<Item?> GetItem(Guid id)
       {
            var item = repository.GetItem(id);
            if (item is null)
            {
                //this function returns status code:404
                return NotFound();
            }
            return item;
       }
    }
}