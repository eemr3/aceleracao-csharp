using TrybeStore.Models;

namespace TrybeStore.Repositories;

public interface IProductRepository
{
  public Task<Product> AddProductAsync(Product product);
  public Task<Product> GetProductById(int produtId);
  public Task<IEnumerable<Product>> GetAllProducts();
}