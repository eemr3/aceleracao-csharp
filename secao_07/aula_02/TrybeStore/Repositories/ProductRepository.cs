using Microsoft.EntityFrameworkCore;
using TrybeStore.Data;
using TrybeStore.Models;

namespace TrybeStore.Repositories;

public class ProductRepository : IProductRepository
{
  private readonly IDatabaseContext _context;
  public ProductRepository(IDatabaseContext context)
  {
    _context = context;
  }

  public async Task<Product> AddProductAsync(Product product)
  {
    var createdProduct = await _context.Products.AddAsync(product);
    await _context.SaveChangesAsync();

    return createdProduct.Entity;
  }

  public async Task<IEnumerable<Product>> GetAllProducts()
  {
    return await _context.Products.ToListAsync();
  }

  public async Task<Product> GetProductById(int productId)
  {
    var product = await _context.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();

    if (product == null) throw new KeyNotFoundException($"Product with ID {productId} not found!");

    return product;
  }
}