
public class ConsoleLoggerProvider : ILoggerProvider
{
  public ILogger CreateLogger (string categoryName)
  {
    return new ConsoleLogger(categoryName);
  }

  public void Dispose()
  {

  }
}