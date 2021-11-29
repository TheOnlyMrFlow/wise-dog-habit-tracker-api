namespace TWD.HabitTracker.Domain.ValueObjects;

public class QuantifiableObjective : IEquatable<QuantifiableObjective>
{
    public decimal? Value { get; }
    
    public string? Unit { get; }

    public QuantifiableObjective(decimal value, string? unit)
    {
        Value = value;
        Unit = unit;
    }
    
    public bool Equals(QuantifiableObjective? other) 
        => other is not null && other.Unit == Unit && other?.Value == Value;

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((QuantifiableObjective)obj);
    }

    public override int GetHashCode() 
        => HashCode.Combine(Unit, Value);
}