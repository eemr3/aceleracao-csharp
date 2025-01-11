namespace AuthService.Exceptions;

public class ForbiddeException : Exception
{
  public ForbiddeException(string message) : base(message) { }
}