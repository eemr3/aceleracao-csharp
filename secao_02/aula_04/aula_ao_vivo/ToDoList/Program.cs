namespace TodoList;
public class Program
{
  public static void Main(string[] args)
  {
    var tasks = new List<string>();
    bool isRuning = true;

    while (isRuning)
    {
      Console.WriteLine("Escolha a opção: ");
      Console.WriteLine("1 - Adicionar uma tarefa: ");
      Console.WriteLine("2 - Veras as tarefas: ");
      Console.WriteLine("3 - Remover uma tarefa: ");
      Console.WriteLine("4 - Sair do sistema");

      bool isNumber = int.TryParse(Console.ReadLine(), out int option);

      switch (option)
      {
        case 1:
          Console.WriteLine("Digite a tarefa: ");
          var task = Console.ReadLine();
          tasks.Add(task!); // Ponto de exclamação: significa que estou afirmando quen ão vai ser nulo
          break;
        case 2:
          Console.WriteLine("Lista de tarefas:");
          foreach (var item in tasks)
          {
            Console.WriteLine(item);
          }
          break;
        case 3:
          Console.WriteLine("Digite a tarefa a ser removida:");
          var taskRemove = Console.ReadLine();
          bool removed = tasks.Remove(taskRemove!);
          if (removed)
          {
            Console.WriteLine("Tarefa removida com sucesso!");
          }
          break;
        case 4:
          isRuning = false;
          break;
        default:
          Console.WriteLine("Opção inválida!");
          break;
      }
    }
  }
}