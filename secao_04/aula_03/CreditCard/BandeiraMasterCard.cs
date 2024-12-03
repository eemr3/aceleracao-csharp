namespace CreditCard;

public class BandeiraMasterCard : IBandeira
{
  public void PagarCredito(double value)
  {
    var minimoValorCredito = 100;
    Console.WriteLine($"[BandeiraMasterCard] Iniciando o pagamento da compra com Visa crédito...");
    if (value < minimoValorCredito)
    {
      Console.WriteLine($"[BandeiraMasterCard] O valor a ser pago R${value} é menor que o valor mínimo para o pagamento no crédito {minimoValorCredito}");
    }
    else
    {
      Console.WriteLine($"[BandeiraMasterCard] Foi pago no crédito o valor R${value} reais!");
    }
  }

  public void PagarDebito(double value)
  {
    Console.WriteLine($"[BandeiraMasterCard] Iniciando o pagamento de compra com Visa débito...");
    Console.WriteLine($"[BandeiraMasterCard] Foi pago no débito o valor de R${value} reais!");
  }
}