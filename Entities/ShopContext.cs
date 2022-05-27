
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NET105.Entities;
namespace NET105 
{
    public class ShopContext : IdentityDbContext<User> 
    {
        public DbSet<Product> Products {get;set;}

        public DbSet<Payment> Payments {get;set;}

        public DbSet<Category> Categories {get;set;}

        public DbSet<Cart> Carts {get;set;}

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) {} 
    }
}