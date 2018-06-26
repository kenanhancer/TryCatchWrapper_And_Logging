using System;
using System.Linq;

public class ConsoleLogger : ILogger
{
  private string _categoryName;

  public ConsoleLogger(string categoryName)
  {
    _categoryName = categoryName;
  }

  public void Log (LogLevel logLevel, Exception exception, Func<string> formatter)
  {
    string[] args = new string[3]{_categoryName, formatter?.Invoke(), exception?.Message};

    Console.WriteLine(String.Join("\n", args.Where(f=> f != null)));
  }
}