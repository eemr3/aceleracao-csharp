using CatalogService.Models;

namespace CatalogService.Repositories;

public interface IProductRepository
{
  public Task<Product> AddProductAsync(Product product);
  public Task<IEnumerable<Product>> GetProductsIdAsync();
  public Task<Product?> GetProductByIdAsync(int id);
  public Task<Product?> UpdateProductAsync(Product product);
  public Task DeleteProduct(int id);
}