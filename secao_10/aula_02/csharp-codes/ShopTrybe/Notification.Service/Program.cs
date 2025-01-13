using System.Text;
using DotNetEnv;
using Newtonsoft.Json;
using Notification.Service.Models;
using Notification.Service.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Notification.Service;

public class Program
{
  private static AutoResetEvent waitHandle = new AutoResetEvent(false);

  public static void Main(string[] args)
  {
    Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));

  Inicio:
    try
    {
      var messageBrokerHost = Environment.GetEnvironmentVariable("MESSAGE_BROKER_HOST");
      var factory = new ConnectionFactory { HostName = messageBrokerHost };
      using var connetion = factory.CreateConnection();
      using var channel = connetion.CreateModel();
      channel.QueueDeclare(queue: "notification",
          durable: false,
          exclusive: false,
          autoDelete: false,
          arguments: null);


      Console.WriteLine("Waiting for new notifications.");

      var consummer = new EventingBasicConsumer(channel);
      consummer.Received += (model, ea) =>
      {
        var body = ea.Body.ToArray();
        Message message = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(body))!;
        try
        {
          EmailService.Send(message);
          Console.WriteLine("Mail sent");
        }
        catch (Exception)
        {
          Console.WriteLine("Mail failed");
        }
      };

      channel.BasicConsume(queue: "notification",
          autoAck: true,
          consumer: consummer);

      Console.CancelKeyPress += (o, e) =>
      {
        Console.WriteLine("Exit...");
        waitHandle.Set();
      };

      waitHandle.WaitOne();
    }
    catch (Exception)
    {
      Console.WriteLine("Error on connect to rabbitmq");
      Console.WriteLine("Trying reconnect");
      System.Threading.Thread.Sleep(5000);
      goto Inicio;
    }
  }
}
