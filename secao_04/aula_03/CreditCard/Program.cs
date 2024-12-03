// Exercíco para fixar o conteúdo sobre injeção de dependecia (DIP)
namespace CreditCard;

public class Program
{
  public static void Main(string[] args)
  {
    var visa = new BandeiraVisa();

    var cartaoTrybeVisa = new CartaoTrybe(visa);

    cartaoTrybeVisa.Pagar("credito", 50);

    var masterCard = new BandeiraMasterCard();

    var cartaoTrybeMasterCard = new CartaoTrybe(masterCard);

    cartaoTrybeMasterCard.Pagar("credito", 50);
  }
}