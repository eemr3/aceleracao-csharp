using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  [HttpPost]
  public IActionResult AddUser([FromBody] User user)
  {
    return Created("", user);
  }
}