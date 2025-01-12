using CatalogService.Dto;
using CatalogService.Models;

namespace CatalogService.Services;

public interface IProductService
{
  public Task<Product> AddProductAsync(ProductDtoRequest product);
  public Task<IEnumerable<Product>> GetProducts();
}