using ProductAPI.Models;

namespace ProductAPI.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> UpdateAsync(int id, Product product);
        Task<bool> DeleteAsync(int id);
        Task<Product> UpdateStockAsync(int id, int newStock);
    }
}
