namespace TWD.HabitTracker.Domain.Entities.Habits.Stamps;

public class Stamp
{
    public Stamp(DateTime date, float? value)
    {
        Date = date;
        Value = value;
    }

    public DateTime Date { get; set; }
    
    public float? Value { get; set; }

    public bool IsOlderThan(Stamp other)
        => Date < other.Date;
}