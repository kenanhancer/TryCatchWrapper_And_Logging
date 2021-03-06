using System;
using System.Threading.Tasks;

class MainClass {
  public static void Main (string[] args) {

    MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
  }

  public static async Task MainAsync(string[] args)
  {
    DefaultLoggerFactory defaultLoggerFactory = new DefaultLoggerFactory();

    defaultLoggerFactory.SetProvider(new ConsoleLoggerProvider());

    ApplicationContext.ConfigureLogger(defaultLoggerFactory, "MainLogger");

    ApplicationContext.Logger.LogDebug("TEST LOG FOR DEBUGGING");
    
    //TryCatch.Invoke(()=> DoAction());

    await TryCatch.InvokeAsync(()=> DoActionAsync());
  }

  public static void DoAction()
  {
    throw new Exception("Exception in DoAction");
  }

  public static Task DoActionAsync()
  {
    return Task.Delay(2000).ContinueWith(t=> throw new Exception("Exception in DoActionAsync"));
  }
}