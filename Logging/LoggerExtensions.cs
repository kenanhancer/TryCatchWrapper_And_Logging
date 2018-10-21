using System;

public static class LoggerExtensions
{
    public static void LogDebug(this ILogger logger, Exception exception, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            return string.Format(message, args);
        };

        logger.Log(LogLevel.Debug, exception, formatter);
    }

    public static void LogDebug(this ILogger logger, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            return string.Format(message, args);
        };

        logger.Log(LogLevel.Debug, null, formatter);
    }

    public static void LogTrace(this ILogger logger, Exception exception, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            return string.Format(message, args);
        };

        logger.Log(LogLevel.Trace, exception, formatter);
    }

    public static void LogTrace(this ILogger logger, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            return string.Format(message, args);
        };

        logger.Log(LogLevel.Trace, null, formatter);
    }

    public static void LogInformation(this ILogger logger, Exception exception, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            return string.Format(message, args);
        };

        logger.Log(LogLevel.Information, exception, formatter);
    }

    public static void LogInformation(this ILogger logger, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            return string.Format(message, args);
        };

        logger.Log(LogLevel.Information, null, formatter);
    }

    public static void LogWarning(this ILogger logger, Exception exception, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            return string.Format(message, args);
        };

        logger.Log(LogLevel.Warning, exception, formatter);
    }

    public static void LogWarning(this ILogger logger, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            if (string.IsNullOrEmpty(message))
            {
                return null;
            }

            return string.Format(message, args);
        };

        logger.Log(LogLevel.Warning, null, formatter);
    }

    public static void LogError(this ILogger logger, Exception exception, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            if (string.IsNullOrEmpty(message))
            {
                return null;
            }

            return string.Format(message, args);
        };

        logger.Log(LogLevel.Error, exception, formatter);
    }

    public static void LogError(this ILogger logger, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            if (string.IsNullOrEmpty(message))
            {
                return null;
            }

            return string.Format(message, args);
        };

        logger.Log(LogLevel.Error, null, formatter);
    }

    public static void LogCritical(this ILogger logger, Exception exception, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            if (string.IsNullOrEmpty(message))
            {
                return null;
            }

            return string.Format(message, args);
        };

        logger.Log(LogLevel.Critical, exception, formatter);
    }

    public static void LogCritical(this ILogger logger, string message, params object[] args)
    {
        Func<string> formatter = () =>
        {
            if (string.IsNullOrEmpty(message))
            {
                return null;
            }

            return string.Format(message, args);
        };

        logger.Log(LogLevel.Critical, null, formatter);
    }

    public static T LogIf<T>(this T arg, bool condition, string message, LogLevel logLevel, params object[] args)
    {
        if (!condition)
        {
            return arg;
        }

        Func<string> formatter = () =>
        {
            return string.Format(message, args);
        };

        ApplicationContext.Logger.Log(logLevel, null, formatter);

        return default(T);
    }

    public static T LogIf<T>(this T arg, Func<T, bool> conditionFactory, string message, LogLevel logLevel, params object[] args)
    {
        return LogIf(arg, conditionFactory(arg), message, logLevel, args);
    }

    public static T LogIfEqual<T>(this T arg, T value, string message, LogLevel logLevel, params object[] args) where T : IEquatable<T>
    {
        return LogIf(arg, arg.Equals(value), message, logLevel, args);
    }

    public static T LogIfNotEqual<T>(this T arg, T value, string message, LogLevel logLevel, params object[] args) where T : IEquatable<T>
    {
        return LogIf(arg, !arg.Equals(value), message, logLevel, args);
    }

    public static string LogIfIsNullOrWhiteSpace(this string arg, string message, LogLevel logLevel, params object[] args)
    {
        return LogIf(arg, string.IsNullOrWhiteSpace(arg), message, logLevel, args);
    }

    public static string LogIfNotIsNullOrWhiteSpace(this string arg, string message, LogLevel logLevel, params object[] args)
    {
        return LogIf(arg, !string.IsNullOrWhiteSpace(arg), message, logLevel, args);
    }

    public static T LogIfNull<T>(this T arg, string message, LogLevel logLevel, params object[] args)
    {
        return LogIf(arg, arg == null, message, logLevel, args);
    }

    public static T LogIfNotNull<T>(this T arg, string message, LogLevel logLevel, params object[] args)
    {
        return LogIf(arg, arg != null, message, logLevel, args);
    }

    public static bool LogIfFalse(this bool arg, string message, LogLevel logLevel, params object[] args)
    {
        return LogIf(arg, !arg, message, logLevel, args);
    }

    public static bool LogIfTrue(this bool arg, string message, LogLevel logLevel, params object[] args)
    {
        return LogIf(arg, arg, message, logLevel, args);
    }
}