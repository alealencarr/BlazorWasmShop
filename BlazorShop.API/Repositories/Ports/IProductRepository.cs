using BlazorShop.API.Entities;

namespace BlazorShop.API.Repositories.Ports
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItens();
        Task<Product> GetItem(int id);

        Task<IEnumerable<Product>> GetItensByCategory(int categoryId);
    }
}
