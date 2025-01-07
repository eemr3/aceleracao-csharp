using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
  [HttpPost]
  public IActionResult AddProduct([FromBody] Product prod)
  {
    return Created("", prod);
  }
}