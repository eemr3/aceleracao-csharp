using Microsoft.EntityFrameworkCore;
using TrybeStore.Data;
using TrybeStore.Models;

namespace TrybeStore.Repositories;

public class CategoryRepository : ICategoryRepository
{
  private readonly IDatabaseContext _context;

  public CategoryRepository(IDatabaseContext context)
  {
    _context = context;
  }

  public async Task<Category> AddCategoryAsync(Category category)
  {
    var createdCategory = await _context.Categories.AddAsync(category);
    await _context.SaveChangesAsync();

    return createdCategory.Entity;
  }

  public async Task<Category> GetCategoryIdAsync(int categoryId)
  {
    var category = await _context.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();

    if (category == null) throw new KeyNotFoundException($"Category with ID {categoryId} not found!");

    return category;
  }

  public async Task<IEnumerable<Category>> GetCategoriesAsync()
  {
    return await _context.Categories.ToListAsync();
  }

  public async void DeleteCategory(int categoryId)
  {
    var categoryExists = await _context.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();

    if (categoryExists == null) throw new KeyNotFoundException($"Category with ID {categoryId} not found!");

    _context.Categories.Remove(categoryExists);
  }

}