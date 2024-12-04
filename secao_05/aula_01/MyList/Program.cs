// Trabalhando com List<T>  Quando trabalhamos com coleções, estamos nos referindo sempre às classes do namespace System.Collections

class Program
{
  public static void Main(string[] args)
  {

    List<string> brands = new List<string>() { "samsung", "dell", "apple", "HP" };

    // Metodo .Add()
    // O método .Add() é utilizado para adicionar itens ao final do objeto do tipo List<T>
    brands.Add("Intel");
    ImpressItensList(brands);
    // Método .Remove()
    // Utilizando quando queremos remover o primeiro elemento do nosso objeto List<T> que corresponda ao especificado no método
    brands.Remove("dell");
    ImpressItensList(brands);
    // .RemoveAt()
    // Utilizado apra remover um elemento que contem o indice passado no parametro do metodo

    brands.RemoveAt(1);
    ImpressItensList(brands);

    // .IndexOf()
    // Utilizado para retornar o indice do elmento na lista, elemento esse passado como paramentro do metodo

    List<int> integers = new List<int>() { 18, 45, 29, 99 };

    integers.ForEach(integer =>
    {
      Console.WriteLine(integer);
    });


    var index = integers.IndexOf(29);
    Console.WriteLine(index);


    // .Sort()
    // Responsável por order o objeto do tipo List<T> por critério especifics
    Console.WriteLine("-----------");
    List<string> animals = new List<string>() { "cachorro", "baleia", "urso", "tigre" };
    foreach (var item in animals)
    {
      Console.WriteLine(item);


    }

    animals.Sort();
    Console.WriteLine("-----------");
    foreach (var item in animals)
    {
      Console.WriteLine(item);


    }



  }

  public static void ImpressItensList(List<string> list)
  {
    foreach (var item in list)
    {
      Console.WriteLine(item);
    }
    Console.WriteLine("-----------");
  }
}

