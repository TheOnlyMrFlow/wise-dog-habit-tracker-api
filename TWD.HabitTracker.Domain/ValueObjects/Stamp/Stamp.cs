namespace TWD.HabitTracker.Domain.ValueObjects.Stamp;

public class Stamp : IEquatable<Stamp>
{
    public Stamp(DateTime date, float? value)
    {
        Date = date;
        Value = value;
    }

    public DateTime Date { get; }
    
    public float? Value { get; }

    public bool IsOlderThan(Stamp other)
        => Date < other.Date;

    public bool HasValue => Value is not null;
    
    public bool Equals(Stamp? other)
    { 
        if (other is null)
            return false;
        
        if (HasValue != other.HasValue)
            return false;
        
        if (HasValue && Value != other.Value)
            return false;

        return true;
    }

    public override bool Equals(object? obj) => obj is Stamp o && Equals(o);

    public override int GetHashCode() => HashCode.Combine(Date.GetHashCode(), Value.GetHashCode());

    public static bool operator ==(Stamp? left, Stamp? right) => (left is null && right is null) || (left is not null && left.Equals(right));

    public static bool operator !=(Stamp left, Stamp right) => !(left == right);
}