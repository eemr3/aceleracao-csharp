using CatalogService.Data;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repositories;

public class ProductRepository : IProductRepository
{
  private readonly AppDBContext _context;

  public ProductRepository(AppDBContext context)
  {
    _context = context;
  }

  public async Task<Product> AddProductAsync(Product product)
  {
    var productAdd = await _context.Products.AddAsync(product);
    await _context.SaveChangesAsync();

    return productAdd.Entity;
  }


  public async Task<IEnumerable<Product>> GetProductsIdAsync()
  {
    return await _context.Products.ToListAsync();
  }

  public async Task<Product?> GetProductByIdAsync(int id)
  {
    var product = await _context.Products.FindAsync(id);

    if (product is null) return null;

    return product;
  }

  public async Task<Product?> UpdateProductAsync(Product product)
  {
    var productExists = await _context.Products.FindAsync(product.Id);

    if (productExists is null) return null;

    _context.Entry(productExists).State = EntityState.Detached;

    _context.Products.Update(product);

    await _context.SaveChangesAsync();

    return product;
  }

  public async Task DeleteProduct(int id)
  {
    var product = await GetProductByIdAsync(id);

    _context.Products.Remove(product!);

    await _context.SaveChangesAsync();
  }
}