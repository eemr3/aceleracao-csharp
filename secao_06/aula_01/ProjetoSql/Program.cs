using System.Globalization;
using ProjetoSql.Models;

class Program
{
  public static void Main(string[] args)
  {
    var context = new StudentContext();

    context.Database.EnsureCreated();

    Console.WriteLine("Insira o nome da pessoa estudante:");
    string? name = Console.ReadLine();
    Console.WriteLine("Insira da data de nascimento da pessoa estudante: (dd/mm/yyyy)");
    string birthday = Console.ReadLine() ?? "";
    Console.WriteLine("Insira o endereço da pessoa estudante:");
    string address = Console.ReadLine() ?? "";
    var studentToInsert = new Student
    {
      Name = name,
      Birthday = DateTime.ParseExact(birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture),
      Address = address
    };

    context.Students.Add(studentToInsert);
    context.SaveChanges();
    Console.WriteLine("Pessoa estudante inserida com sucesso!");

    Console.WriteLine("Pessoas estudantes cadastradas no banco de dados:");
    var students = context.Students.ToList();
    foreach (var student in students)
    {
      Console.WriteLine($"{student.Id} - {student.Name} - {student.Birthday} - {student.Address}");
    }
  }
}