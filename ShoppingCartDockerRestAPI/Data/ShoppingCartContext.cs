using Microsoft.EntityFrameworkCore;
using ShoppingCartDockerRestAPI.Models;

namespace ShoppingCartDockerRestAPI.Data;

public class ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : DbContext(options)
{
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; init; }
        
    
}