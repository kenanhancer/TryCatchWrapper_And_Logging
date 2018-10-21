public static class ApplicationContext
{
    public static ILogger Logger { get; private set; } = new ConsoleLogger("DefaultLogger");

    public static void ConfigureLogger(ILoggerFactory loggerFactory, string loggerName)
    {
        Logger = loggerFactory.CreateLogger(loggerName);
    }
}