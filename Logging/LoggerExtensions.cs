using System;

public static class LoggerExtensions
{
  public static void LogDebug (this ILogger logger, Exception exception, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      return String.Format(message, args);
    };

    logger.Log(LogLevel.Debug, exception, formatter);
  }

  public static void LogDebug (this ILogger logger, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      return String.Format(message, args);
    };

    logger.Log(LogLevel.Debug, null, formatter);
  }

  public static void LogTrace (this ILogger logger, Exception exception, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      return String.Format(message, args);
    };
    
    logger.Log(LogLevel.Trace, exception, formatter);
  }

  public static void LogTrace (this ILogger logger, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      return String.Format(message, args);
    };
    
    logger.Log(LogLevel.Trace, null, formatter);
  }

  public static void LogInformation (this ILogger logger, Exception exception, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      return String.Format(message, args);
    };
    
    logger.Log(LogLevel.Information, exception, formatter);
  }

  public static void LogInformation (this ILogger logger, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      return String.Format(message, args);
    };
    
    logger.Log(LogLevel.Information, null, formatter);
  }

  public static void LogWarning (this ILogger logger, Exception exception, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      return String.Format(message, args);
    };
    
    logger.Log(LogLevel.Warning, exception, formatter);
  }

  public static void LogWarning (this ILogger logger, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      if(String.IsNullOrEmpty(message))
        return null;

      return String.Format(message, args);
    };
    
    logger.Log(LogLevel.Warning, null, formatter);
  }

  public static void LogError (this ILogger logger, Exception exception, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      if(String.IsNullOrEmpty(message))
        return null;

      return String.Format(message, args);
    };
    
    logger.Log(LogLevel.Error, exception, formatter);
  }

  public static void LogError (this ILogger logger, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      if(String.IsNullOrEmpty(message))
        return null;

      return String.Format(message, args);
    };
    
    logger.Log(LogLevel.Error, null, formatter);
  }

  public static void LogCritical (this ILogger logger, Exception exception, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      if(String.IsNullOrEmpty(message))
        return null;

      return String.Format(message, args);
    };
    
    logger.Log(LogLevel.Critical, exception, formatter);
  }

  public static void LogCritical (this ILogger logger, string message, params object[] args)
  {
    Func<string> formatter = ()=>
    {
      if(String.IsNullOrEmpty(message))
        return null;
        
      return String.Format(message, args);
    };
    
    logger.Log(LogLevel.Critical, null, formatter);
  }
}