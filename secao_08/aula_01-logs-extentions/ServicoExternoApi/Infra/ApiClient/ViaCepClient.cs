using System.Net.Http.Headers;

namespace ServicoExternoApi.Infra.Apiclient;

public class ViaCepClient : IViaCepClient
{
  private readonly HttpClient _httpClient;
  private readonly string _baseUrl = "https://viacep.com.br/ws/";
  public ViaCepClient(HttpClient httpClient)
  {
    _httpClient = httpClient;
    _httpClient.BaseAddress = new Uri(_baseUrl);

    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("aspnet-user-agent");
  }
  public async Task<object> GetCepAsync(string cep)
  {
    if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8)
    {
      throw new ArgumentException("Invalid CEP format.");
    }

    var response = await _httpClient.GetAsync($"{cep}/json/");

    if (!response.IsSuccessStatusCode)
    {
      throw new ArgumentException("Invalid CEP format.");
      // throw new KeyNotFoundException($"Address not found for CEP: {cep}.");
    }

    var result = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();

    if (result == null || result.ContainsKey("erro")) { throw new KeyNotFoundException($"Address not found for CEP: {cep}."); }

    return result;
  }
}