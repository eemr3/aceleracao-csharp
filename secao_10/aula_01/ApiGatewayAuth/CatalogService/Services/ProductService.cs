using CatalogService.Dto;
using CatalogService.Models;
using CatalogService.Repositories;

namespace CatalogService.Services;

public class ProductService : IProductService
{
  private readonly IProductRepository _repository;

  public ProductService(IProductRepository repository)
  {
    _repository = repository;
  }
  public async Task<Product> AddProductAsync(ProductDtoRequest productDto)
  {
    var product = new Product
    {
      Name = productDto.Name,
      Brand = productDto.Brand,
      Price = productDto.Price,
    };

    return await _repository.AddProductAsync(product);
  }

  public async Task<IEnumerable<Product>> GetProducts()
  {
    return await _repository.GetProducts();
  }
}
