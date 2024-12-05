using AggregationLinq;

class Program
{
  public static void Main(string[] args)
  {
    // ExempleAggregation();
    List<Students> students = new List<Students>(){
      new Students {Name = "Maria", Grade = new List<Discipline>{
        new Discipline{Name = "Matemática", Grade = 80},
        new Discipline {Name = "Geografia", Grade = 74}
      }},
      new Students {Name = "Joana", Grade = new List<Discipline>{
        new Discipline {Name = "Matemática", Grade = 35},
        new Discipline {Name = "Geografia", Grade = 40}
      }},
      new Students {Name = "Rebeca", Grade = new List<Discipline>{
        new Discipline {Name = "Matemática", Grade = 60},
        new Discipline {Name = "Geografia", Grade = 100},
      }}
    };

    var studentGrades = from student in students
                        select new
                        {
                          student.Name,
                          Grade = student?.Grade?.Average(g => g.Grade)
                        };

    foreach (var student in studentGrades)
    {
      Console.WriteLine(student);
    }
  }

  public static void ExempleAggregation()
  {
    int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

    var numQuery = from nun in numbers
                   where (nun % 2) == 0
                   select nun;

    /*
      Count():
      Método para qualquer tipo de consulta e coleções.
      Retorna o número de elementos da consulta ou lista que implementa a Interface IEnumerable
    */
    Console.WriteLine(numQuery.Count());

    /*
      Max():
      Método para consultas ou coleções numéricas.
      Retorna o maior elemento da consulta ou lista que implementa a Interface IEnumerable
    */
    Console.WriteLine(numQuery.Max());

    /*
      Min():
      Método para consultas ou coleções numéricas.
      Retorna o menor elemento da consulta ou lista que implementa a Interface IEnumerable
    */
    Console.WriteLine(numQuery.Min());

    /*
      Sum():
      Método para consultas ou coleções numéricas.
      Retorna a soma dos elementos da consulta ou lista que implementa a Interface IEnumerable
    */
    Console.WriteLine(numQuery.Sum());

    /*
      Average():
      Método para consultas ou coleções numéricas.
      Retorna a média dos elementos da consulta ou lista que implementa a Interface IEnumerable
    */
    Console.WriteLine(numQuery.Average());
  }
}
