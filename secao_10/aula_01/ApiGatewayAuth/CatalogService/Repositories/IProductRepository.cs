using CatalogService.Models;

namespace CatalogService.Repositories;
public interface IProductRepository
{
  public Task<Product> AddProductAsync(Product product);
  public Task<IEnumerable<Product>> GetProducts();
}