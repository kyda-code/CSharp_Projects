using ShoppingCartDockerRestAPI.Models;

namespace ShoppingCartDockerRestAPI.Services;

public interface IShoppingCartService
{
    Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItems();
    Task<ShoppingCartItem> GetShoppingCartItemById(Guid id);
    Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem);
    Task<ShoppingCartItem> UpdateShoppingCartItem(Guid id, ShoppingCartItem shoppingCartItem);
    Task<bool> DeleteShoppingCartItem(Guid id);
}