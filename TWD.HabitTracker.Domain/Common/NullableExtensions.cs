namespace TWD.HabitTracker.Domain.Common;

public static class NullableExtensions
{
    public static TResult Match<TNullable, TResult>(this TNullable? nullable, Func<TResult> whenNull, Func<TNullable, TResult> whenNotNull)
    {
        return nullable is null ? whenNull() : whenNotNull(nullable);
    }
    
    public static Task<TResult> Match<TNullable, TResult>(this TNullable? nullable, Func<TResult> whenNull, Func<TNullable, Task<TResult>> whenNotNull)
    {
        return nullable is null 
            ? Task.FromResult(whenNull()) 
            : whenNotNull(nullable);
    }
    
    public static Task Match<TNullable>(this TNullable? nullable, Action whenNull, Func<TNullable, Task> whenNotNull)
    {
        if (nullable is not null)
            return whenNotNull(nullable);
        
        whenNull();
        return Task.CompletedTask;
    }
}