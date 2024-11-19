public class Program
{
  public static void Main(string[] args)
  {
    // Funções da Classe String
    // Existem diversas funções que são muito utilizadas durante o desenvolvimento de uma aplicação em C# e são pertencentes da classe String, como:
    /*
      Concat()
      Split()
      IndexOf()
      Contains()
      Join()
    */

    MetodoConcat();
    MetodoSplit();
    MetodoIndexOf();
    MetodoContains();
    MetodoJoin();
  }
  public static void MetodoConcat()
  {
    string textOne = "Você está aprendendo sobre ";
    string textTwo = "Strings em C#, ";
    string textThree = "e agora sabe concatenar textos utilizando a função Concat()!";

    string concatResult = string.Concat(textOne, textTwo, textThree);
    Console.WriteLine(concatResult);

  }

  public static void MetodoSplit()
  {
    string emails = "email1@trybe.com;email2@trybe.com;email3@trybe.com";
    string[] emailsSend = emails.Split(';');

    foreach (string email in emailsSend)
    {
      Console.WriteLine(email);
    }
  }

  public static void MetodoIndexOf()
  {
    //Procurando um index na string 
    string trybe = "Trybe";
    int index = trybe.IndexOf("y");

    Console.WriteLine(index);
  }

  public static void MetodoContains()
  {
    // string[] languages = { "C#", "Python", "JavaScript", "Java" };

    // Console.WriteLine(languages.Contains("C#"));

    List<string> languages = new List<string> { "c#", "java", "javascript", "python" };
    Console.WriteLine(languages.Contains("java"));
  }

  public static void MetodoJoin()
  {
    IEnumerable<int> listNumbers = Enumerable.Range(1, 10);

    string numbersText = string.Join(',', listNumbers);
    Console.WriteLine(numbersText);
  }
}