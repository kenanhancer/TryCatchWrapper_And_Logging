public class DefaultLoggerFactory : ILoggerFactory
{
    private ILoggerProvider _provider;

    public ILogger CreateLogger(string categoryName)
    {
        return _provider.CreateLogger(categoryName);
    }

    public void SetProvider(ILoggerProvider provider)
    {
        _provider = provider;
    }

    public void Dispose()
    {
        _provider.Dispose();
    }
}