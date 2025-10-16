using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Interfaces;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context) { _context = context; }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public async Task<Product> UpdateAsync(int id, Product product)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod == null) return null;
            prod.name = product.name;
            prod.description = product.description;
            prod.price = product.price;
            prod.stock = product.stock;
            await _context.SaveChangesAsync();
            return prod;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) {  return false; }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product> UpdateStockAsync(int id, int newStock)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;
            product.stock = newStock;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
