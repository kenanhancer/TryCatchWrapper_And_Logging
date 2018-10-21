using System;

public interface ILogger
{
    void Log(LogLevel logLevel, Exception exception, Func<string> formatter);
}