using System;
using System.Threading.Tasks;

public static class TryCatch
{
    #region Invoke

    public static void Invoke(Action action, Action<Exception> finalAction = null)
    {
        Invoke<object>(() =>
        {
            action();

            return null;
        },
        null,
        finalAction);
    }

    public static T Invoke<T>(Func<T> action, T defaultValue, Action<Exception> finalAction = null)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        Exception exception = null;
        Task task = null;

        try
        {
            T returnValue = action();

            return returnValue;
        }
        catch (Exception ex)
        {
            exception = ex;

            ApplicationContext.Logger.LogError(ex, null);

            if (finalAction != null)
            {
                finalAction?.Invoke(ex);
            }
        }
        finally
        {
            if (task == null)
            {
                finalAction?.Invoke(exception);
            }
        }

        return default(T);
    }

    public static T Invoke<T>(Func<T> action, Action<Exception> finalAction = null)
    {
        return Invoke<T>(action, default(T), finalAction);
    }

    #endregion Invoke

    #region InvokeAsync

    public static async Task InvokeAsync(Func<Task> action, Func<Exception, Task> finalAction = null)
    {
        await InvokeAsync<object>(async () =>
        {
            await action();

            return null;
        },
        null, finalAction);
    }

    public static async Task<T> InvokeAsync<T>(Func<Task<T>> action, T defaultValue, Func<Exception, Task> finalAction = null)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        Task<T> returnValue = await action().ContinueWith(async t =>
        {
            //T result = t.ConfigureAwait(false).GetAwaiter().GetResult();

            if (t.Status == TaskStatus.Faulted)
            {
                //result = defaultValue;

                ApplicationContext.Logger.LogError(t.Exception, null);

                if (finalAction != null)
                {
                    await finalAction(t.Exception);
                }

                //var fromResultMi = typeof(Task).GetMethod("FromResult").MakeGenericMethod(typeof(T));

                return default(T);// fromResultMi.Invoke(null, new object[] { null });
            }

            if (finalAction != null)
            {
                await finalAction(t.Exception);
            }

            return await t;
        });

        return await returnValue;
    }

    public static async Task<T> InvokeAsync<T>(Func<Task<T>> action, Func<Exception, Task> finalAction = null)
    {
        return await InvokeAsync<T>(action, default(T), finalAction);
    }

    #endregion InvokeAsync
}