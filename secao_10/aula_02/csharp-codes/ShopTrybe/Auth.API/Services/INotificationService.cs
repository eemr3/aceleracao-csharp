using Auth.API.Models;

namespace Auth.API.Services;
public interface INotificationService
{
  public void Send(Message notification);
}