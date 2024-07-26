using Microsoft.AspNetCore.Mvc;
using ShoppingCartDockerRestAPI.Models;
using ShoppingCartDockerRestAPI.Services;

namespace ShoppingCartDockerRestAPI.Controllers;

[ApiController]
[Route("api/[controller]/items")]
public class ShoppingCartController(IShoppingCartService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShoppingCartItem>>> GetShoppingCartItems()
    {
        return Ok(await service.GetShoppingCartItems());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShoppingCartItem>> GetShoppingCartItem(Guid id)
    {
        var shoppingCartItem = await service.GetShoppingCartItemById(id);

        if (shoppingCartItem == null)
        {
            return NotFound();
        }

        return Ok(shoppingCartItem);
    }
    
    [HttpPost]
    public async Task<ActionResult<ShoppingCartItem>> AddShoppingCartItem(ShoppingCartItem shoppingCartItem)
    {
        await service.AddShoppingCartItem(shoppingCartItem);
        
        return CreatedAtAction("GetShoppingCartItem", new { id = shoppingCartItem.Id }, shoppingCartItem);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShoppingCartItem(Guid id, ShoppingCartItem shoppingCartItem)
    {
        if (id != shoppingCartItem.Id)
        {
            return BadRequest();
        }

        await service.UpdateShoppingCartItem(id, shoppingCartItem);
        
        return NoContent();
    }
        
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShoppingCartItem(Guid id)
    {
        var result = await service.DeleteShoppingCartItem(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

}