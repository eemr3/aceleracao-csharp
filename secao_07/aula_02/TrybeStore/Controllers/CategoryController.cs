using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrybeStore.DTO;
using TrybeStore.Models;
using TrybeStore.Repositories;

namespace TrybeStore.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
  private readonly ICategoryRepository _repository;

  public CategoryController(ICategoryRepository repository)
  {
    _repository = repository;
  }

  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [Authorize(Policy = "Gerente")]
  [HttpPost]
  public async Task<IActionResult> AddCategory([FromBody] Category category)
  {
    var createdCategory = await _repository.AddCategoryAsync(category);

    return Created("", createdCategory);
  }

}