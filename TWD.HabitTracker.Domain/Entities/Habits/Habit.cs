namespace TWD.HabitTracker.Domain.Entities.Habits;

public class Habit
{
    public Habit() { }
    
    public Habit(string name)
    {
        Name = name;
    }
    
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;
}