using CatalogService.Dto;
using CatalogService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
  private readonly IProductService _service;

  public ProductController(IProductService service)
  {
    _service = service;
  }

  [HttpPost()]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> AddProduct([FromBody] ProductDtoRequest productDto)
  {
    var result = await _service.AddProductAsync(productDto);

    return Created("", result);
  }

  [HttpGet()]
  public async Task<IActionResult> GetProducts()
  {
    var products = await _service.GetProducts();

    return Ok(products);
  }
}