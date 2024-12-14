using TrybeStore.Models;

namespace TrybeStore.Repositories;

public interface ICategoryRepository
{
  public Task<Category> AddCategoryAsync(Category category);
  public Task<Category> GetCategoryIdAsync(int categoryId);
  public Task<IEnumerable<Category>> GetCategoriesAsync();
  public void DeleteCategory(int categoryId);
}