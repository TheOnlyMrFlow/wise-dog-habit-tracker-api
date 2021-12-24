namespace TWD.HabitTracker.Domain.ValueObjects;

public class HabitObjective : IEquatable<HabitObjective>
{
    public float Value { get; }
    
    public string? Unit { get; }

    public HabitObjective(float value, string? unit)
    {
        Value = value;
        Unit = unit;
    }
    
    public bool Equals(HabitObjective? other) 
        => other is not null && other.Unit == Unit && other?.Value == Value;

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((HabitObjective)obj);
    }

    public override int GetHashCode() 
        => HashCode.Combine(Unit, Value);
}