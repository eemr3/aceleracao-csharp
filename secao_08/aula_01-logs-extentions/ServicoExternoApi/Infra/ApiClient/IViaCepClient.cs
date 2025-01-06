namespace ServicoExternoApi.Infra.Apiclient;

public interface IViaCepClient
{
  Task<object> GetCepAsync(string cep);
}