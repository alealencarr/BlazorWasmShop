using BlazorShop.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cart>? Carts { get; set; }
        public DbSet<CartItem>? CartItens { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData( new Category
            {
                Id = 1, 
                Name = "Beleza",
                IconCSS = "fas fa-spa"

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Glossier - Beleza Kit",
                Description = "Um kit.",
                ImageUrl = "/Imagens/Beleza/Beleza1.png",
                Price = 100,
                Amount = 100,
                CategoryId = 1
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Alexandre Santos" 
            });
        }
    }
}
