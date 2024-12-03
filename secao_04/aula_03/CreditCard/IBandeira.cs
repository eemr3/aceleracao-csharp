namespace CreditCard;

public interface IBandeira
{
  public void PagarDebito(double value);
  public void PagarCredito(double value);
}