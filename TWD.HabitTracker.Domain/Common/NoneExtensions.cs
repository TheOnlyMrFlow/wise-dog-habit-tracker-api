using OneOf.Types;

namespace TWD.HabitTracker.Domain.Common;

public static class NoneExtensions
{
    public static OneOf.OneOf<T, None> Of<T>() => new None();
}