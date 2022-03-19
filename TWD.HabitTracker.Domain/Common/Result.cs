namespace TWD.HabitTracker.Domain.Common;

public class Result<TSuccess, TError>
{
    private readonly TSuccess? _success;
    private readonly TError? _error;
    private readonly bool _isSuccess;

    public Result(TSuccess success)
    {
        _success = success;
        _isSuccess = true;
    }

    public Result(TError error)
    {
        _error = error;
        _isSuccess = false;
    }

    public T Match<T>(Func<TSuccess, T> successHandler, Func<TError, T> errorHandler)
        => _isSuccess ? successHandler(_success!) : errorHandler(_error!);

    public void Match(Action<TSuccess> successHandler, Action<TError> errorHandler)
    {
        if (_isSuccess)
            successHandler(_success!);
        else
            errorHandler(_error!);
    } 
    
    public Task Match(Func<TSuccess, Task> successHandler, Action<TError> errorHandler)
    {
        if (_isSuccess)
            return successHandler(_success!);
        
        errorHandler(_error!);
        return Task.CompletedTask;
    }
    
    public Task Match(Action<TSuccess> successHandler, Func<TError, Task> errorHandler)
    {
        if (_isSuccess)
        {
            successHandler(_success!);
            return Task.CompletedTask;
        }
        
        return errorHandler(_error!);
    } 
}