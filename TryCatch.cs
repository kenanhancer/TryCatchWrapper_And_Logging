using System;
using System.Threading.Tasks;

public static class TryCatch
{
    #region Invoke

    public static void Invoke(Action action)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));

        try
        {
            action.Invoke();
        }
        catch (Exception ex)
        {
            ApplicationLogging.Logger.LogError(ex, null);
        }
    }

    public static T Invoke<T>(Func<T> action, T defaultValue)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));

        try
        {
            return action();
        }
        catch (Exception ex)
        {
            ApplicationLogging.Logger.LogError(ex, null);
        }

        return defaultValue;
    }

    public static T Invoke<T>(Func<T> action)
    {
        return Invoke<T>(action, default(T));
    }

    #endregion Invoke

    #region InvokeAsync

    public static async Task InvokeAsync(Func<Task> action)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));

        try
        {
            await action();
        }
        catch (Exception ex)
        {
            ApplicationLogging.Logger.LogError(ex, null);
        }
    }

    public static async Task<T> InvokeAsync<T>(Func<Task<T>> action, T defaultValue)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));

        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            ApplicationLogging.Logger.LogError(ex, null);
        }

        return defaultValue;
    }

    public static async Task<T> InvokeAsync<T>(Func<Task<T>> action)
    {
        return await InvokeAsync<T>(action, default(T));
    }

    #endregion InvokeAsync
}