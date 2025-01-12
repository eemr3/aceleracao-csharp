using CatalogService.Data;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repositories;

public class ProductRepository : IProductRepository
{
  private readonly CatalogDbContext _context;

  public ProductRepository(CatalogDbContext context)
  {
    _context = context;
  }
  public async Task<Product> AddProductAsync(Product product)
  {

    var productAdd = await _context.Products.AddAsync(product);

    await _context.SaveChangesAsync();

    return productAdd.Entity;
  }

  public async Task<IEnumerable<Product>> GetProducts()
  {
    return await _context.Products.ToListAsync();
  }
}