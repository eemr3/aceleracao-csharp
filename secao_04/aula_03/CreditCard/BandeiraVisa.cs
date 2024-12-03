namespace CreditCard;
public class BandeiraVisa : IBandeira
{
  public void PagarCredito(double value)
  {
    var minimoValorCredito = 50;
    Console.WriteLine($"[BandeiraVisa] Iniciando o pagamento da compra com Visa crédito...");
    if (value < minimoValorCredito)
    {
      Console.WriteLine($"[BandeiraVisa] O valor a ser pago R${value} é menor que o valor mínimo para o pagamento no crédito {minimoValorCredito}");
    }
    else
    {
      Console.WriteLine($"[BandeiraVisa] Foi pago no crédito o valor R${value} reais!");
    }
  }

  public void PagarDebito(double value)
  {
    Console.WriteLine($"[BandeiraVisa] Iniciando o pagamento de compra com Visa débito...");
    Console.WriteLine($"[BandeiraVisa] Foi pago no débito o valor de R${value} reais!");
  }
}