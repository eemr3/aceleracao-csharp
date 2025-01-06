using Microsoft.AspNetCore.Mvc;

namespace PokemonApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
  private readonly HttpClient _httpClient;
  private readonly ILogger<PokemonController> _logger;
  private readonly string baseUrl = "https://pokeapi.co/api/v2/pokemon";
  public PokemonController(HttpClient httpClient, ILogger<PokemonController> logger)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  [HttpGet("{pokeName}")]
  public async Task<IActionResult> GetPokemos(string pokeName)
  {
    var pokemon = await _httpClient.GetAsync($"{baseUrl}/{pokeName}");
    if (pokemon.IsSuccessStatusCode)
    {
      var content = await pokemon.Content.ReadAsStringAsync();
      _logger.LogInformation("Pokemon retrivied: ({pokeName})", pokeName);
      return Content(content, "application/json");
    }
    else
    {
      _logger.LogWarning("Error: Pokemon not found ({pokeName})", pokeName);
      return NotFound("Pokemon not found!");
    }
  }
}