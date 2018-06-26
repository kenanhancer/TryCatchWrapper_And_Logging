	using System;
  
  public interface ILoggerProvider : IDisposable
	{
		ILogger CreateLogger (string categoryName);
	}