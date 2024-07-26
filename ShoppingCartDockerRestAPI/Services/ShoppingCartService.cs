using Microsoft.EntityFrameworkCore;
using ShoppingCartDockerRestAPI.Data;
using ShoppingCartDockerRestAPI.Models;

namespace ShoppingCartDockerRestAPI.Services;

public class ShoppingCartService(ShoppingCartContext context) : IShoppingCartService
{
    public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems()
    {
        return await context.ShoppingCartItems.ToListAsync();
    }

    public async Task<ShoppingCartItem> GetShoppingCartItemById(Guid id)
    {
        return await context.ShoppingCartItems.FindAsync(id);
    }

    public async Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem)
    {
        context.ShoppingCartItems.Add(shoppingCartItem);
        await context.SaveChangesAsync();

        return shoppingCartItem;
    }

    public async Task<ShoppingCartItem> UpdateShoppingCartItem(Guid id, ShoppingCartItem shoppingCartItem)
    {
        if (id != shoppingCartItem.Id)
        {
            throw new InvalidOperationException();
        }

        context.Entry(shoppingCartItem).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return shoppingCartItem;
    }

    public async Task<bool> DeleteShoppingCartItem(Guid id)
    {
        var shoppingCartItem = await context.ShoppingCartItems.FindAsync(id);

        if (shoppingCartItem == null)
        {
            return false;
        }

        context.ShoppingCartItems.Remove(shoppingCartItem);
        await context.SaveChangesAsync();

        return true;
    }
}