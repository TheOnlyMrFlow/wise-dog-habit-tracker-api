namespace TWD.HabitTracker.Domain.Common;

public class Either<TLeft, TRight>
{
    private readonly TLeft? _left;
    private readonly TRight? _right;
    private readonly bool _isLeft;

    public Either(TLeft left)
    {
        _left = left;
        _isLeft = true;
    }

    public Either(TRight right)
    {
        _right = right;
        _isLeft = false;
    }

    public T Match<T>(Func<TLeft, T> leftFunc, Func<TRight, T> rightFunc)
        => _isLeft ? leftFunc(_left!) : rightFunc(_right!);

    public void Match(Action<TLeft> leftFunc, Action<TRight> rightFunc)
    {
        if (_isLeft)
            leftFunc(_left!);
        else
            rightFunc(_right!);
    } 
    
    public Task Match(Func<TLeft, Task> leftFunc, Action<TRight> rightFunc)
    {
        if (_isLeft)
            return leftFunc(_left!);
        
        rightFunc(_right!);
        return Task.CompletedTask;
    } 
    
    public Task Match(Action<TLeft> leftFunc, Func<TRight, Task> rightFunc)
    {
        if (_isLeft)
        {
            leftFunc(_left!);
            return Task.CompletedTask;
        }
        
        return rightFunc(_right!);
    } 
}