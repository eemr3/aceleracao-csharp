using Microsoft.AspNetCore.Mvc;
using ServicoExternoApi.Filteres;
using ServicoExternoApi.Infra.Apiclient;

namespace ServicoExternoApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CepController : ControllerBase
{
  private readonly IViaCepClient _viaCepClient;

  public CepController(IViaCepClient viaCepClient)
  {
    _viaCepClient = viaCepClient;
  }

  [HttpGet("{cep}")]
  [TypeFilter(typeof(CustomExceptionFilter))]
  public async Task<IActionResult> GetCep(string cep)
  {
    var response = await _viaCepClient.GetCepAsync(cep);
    if (response == null) return NotFound();
    return Ok(response);
  }
}