using CatalogService.DTO;
using CatalogService.Models;

namespace CatalogService.Services;

public interface IProductService
{
  public Task<Product> AddProductAsync(ProductDtoRequest productDto);
  public Task<IEnumerable<Product>> GetProductsIdAsync();
  public Task<Product?> GetProductByIdAsync(int id);
  public Task<Product?> UpdateProductAsync(Product product);
  public Task DeleteProduct(int id);
}