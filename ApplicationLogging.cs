
public static class ApplicationLogging
{
    public static ILogger Logger { get; private set; }

    public static void ConfigureLogger(ILoggerFactory loggerFactory)
    {
        Logger = loggerFactory.CreateLogger("TestProject.log");
    }
}