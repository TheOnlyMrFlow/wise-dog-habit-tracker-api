using TWD.HabitTracker.Domain.Common;
using TWD.HabitTracker.Domain.ValueObjects.Stamp;

namespace TWD.HabitTracker.Domain.Entities.Habits.Errors;

public class StampAlreadyExistsError
{
    
}

public class StampMushHaveValueError
{
    
}

public class AddStampError: Either<StampAlreadyExistsError, StampMushHaveValueError>
{
    public AddStampError(StampAlreadyExistsError left) : base(left) { }

    public AddStampError(StampMushHaveValueError right) : base(right) { }
    
    public static AddStampError StampAlreadyExists() => new AddStampError(new StampAlreadyExistsError());
    
    public static AddStampError StampMushHaveValue() => new AddStampError(new StampMushHaveValueError());
}