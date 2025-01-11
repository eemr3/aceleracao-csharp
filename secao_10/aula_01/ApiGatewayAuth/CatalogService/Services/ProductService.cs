using CatalogService.DTO;
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
      Price = productDto.Price
    };

    return await _repository.AddProductAsync(product);

  }

  public async Task<Product?> GetProductByIdAsync(int id)
  {
    var product = await _repository.GetProductByIdAsync(id);

    if (product is null) throw new KeyNotFoundException($"O produto com o ID {id} não foi encontrado.");

    return product;
  }

  public async Task<IEnumerable<Product>> GetProductsIdAsync()
  {
    return await _repository.GetProductsIdAsync();
  }

  public async Task<Product?> UpdateProductAsync(Product product)
  {
    var productExist = await _repository.GetProductByIdAsync(product.Id);

    if (productExist is null) throw new KeyNotFoundException($"O produto com o ID {product.Id} não foi encontrado.");

    return await _repository.UpdateProductAsync(product);
  }

  public async Task DeleteProduct(int id)
  {
    var productExist = await _repository.GetProductByIdAsync(id);

    if (productExist is null) throw new KeyNotFoundException($"O produto com o ID {id} não foi encontrado.");

    await _repository.DeleteProduct(id);
  }
}