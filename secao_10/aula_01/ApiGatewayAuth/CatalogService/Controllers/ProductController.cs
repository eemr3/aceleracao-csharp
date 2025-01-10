using CatalogService.DTO;
using CatalogService.Filters;
using CatalogService.Models;
using CatalogService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers;

[ApiController]
[Route("api/products")]
[TypeFilter(typeof(CustomExceptionsFilter))]
public class ProductController : ControllerBase
{
  private readonly IProductService _service;

  public ProductController(IProductService service)
  {
    _service = service;
  }

  [HttpPost]
  public async Task<IActionResult> AddProduct([FromBody] ProductDtoRequest productDto)
  {
    var product = await _service.AddProductAsync(productDto);

    return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetProductById(int id)
  {
    var product = await _service.GetProductByIdAsync(id);

    return Ok(product);
  }

  [HttpGet]
  public async Task<IActionResult> GetProducts()
  {
    var products = await _service.GetProductsIdAsync();

    return Ok(products);
  }

  [HttpPut]
  public async Task<IActionResult> UpdateProduct([FromBody] Product product)
  {
    var productUpdated = await _service.UpdateProductAsync(product);

    return Ok(productUpdated);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteProduct(int id)
  {
    await _service.DeleteProduct(id);

    return NoContent();
  }
}