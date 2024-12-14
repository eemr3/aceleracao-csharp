namespace TrybeStore.Exceptions;

public class UnauthorizedException : Exception
{
  public UnauthorizedException(string message) : base(message) { }
}