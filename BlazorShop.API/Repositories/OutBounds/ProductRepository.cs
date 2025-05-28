using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using BlazorShop.API.Repositories.Ports;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Repositories.OutBounds
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<Product?> GetItem(int id)
        {
            return await _context.Products
                .Include(c => c.Category)
                .AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
            
        }

        public async Task<IEnumerable<Product>> GetItens()
        {
            return await _context.Products
             .Include(c => c.Category)
             .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetItensByCategory(int categoryId)
        {
            return await _context.Products
            .Include(c => c.Category)
            .AsNoTracking()
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();
        }
    }
}
