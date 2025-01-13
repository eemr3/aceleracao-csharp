using System.Text;
using Auth.API.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Auth.API.Services;

public class NotificationService : INotificationService
{
  public void Send(Message message)
  {
    var _factory = new ConnectionFactory { HostName = "localhost" };
    using var connection = _factory.CreateConnection();
    using var channel = connection.CreateModel();
    {
      channel.QueueDeclare(queue: "notification",
          durable: false,
          exclusive: false,
          autoDelete: false,
          arguments: null);

      string messageSerialize = JsonConvert.SerializeObject(message);
      var body = Encoding.UTF8.GetBytes(messageSerialize);

      channel.BasicPublish(exchange: string.Empty,
          routingKey: "notification",
          basicProperties: null,
          body: body);
    }
  }
}