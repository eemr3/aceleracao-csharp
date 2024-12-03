namespace CreditCard;
public class CartaoTrybe
{
  private IBandeira _bandeira;

  public CartaoTrybe(IBandeira bandeira)
  {
    _bandeira = bandeira;
  }

  public void Pagar(string funcao, double valor)
  {
    switch (funcao)
    {
      case "debito":
        _bandeira.PagarDebito(valor);
        break;
      case "credito":
        _bandeira.PagarCredito(valor);
        break;
      default: throw new ArgumentException("Função inválida!");
    }
  }
}