using System;
using System.Linq;

public class ConsoleLogger : ILogger
{
    private readonly string _categoryName;

    public ConsoleLogger(string categoryName)
    {
        _categoryName = categoryName;
    }

    public void Log(LogLevel logLevel, Exception exception, Func<string> formatter)
    {
        string[] args = new string[3] { _categoryName, formatter?.Invoke(), exception?.Message };

        string message = string.Join("\n", args.Where(f => f != null));

        Console.WriteLine(message);
    }
}