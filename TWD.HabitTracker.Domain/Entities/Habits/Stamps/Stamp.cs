namespace TWD.HabitTracker.Domain.Entities.Habits.Stamps;

public abstract class Stamp
{
    public DateTime Date { get; set; }
    
    public double? Value { get; set; }
}